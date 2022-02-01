using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Helpers;
using Grup22.Context;
using Grup22.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Grup22.Controllers
{
    public class SellerUserController : Controller
    {
        private readonly KurumsalContext _context;
        public int loginNumber = 0;
        public SellerUserController(KurumsalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("userId") == null)
                return View("~/Views/FactoryUser/Login.cshtml");
            else
                return RedirectToAction("Index","Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(FactoryUser user)
        {
            if (HttpContext.Session.GetInt32("loginNumber") == null)
                HttpContext.Session.SetInt32("loginNumber", loginNumber);
            else
                loginNumber = (int)HttpContext.Session.GetInt32("loginNumber");
            if (loginNumber >= 3)
            {
                var captchaImage = HttpContext.Request.Form["g-recaptcha-response"];
                if (string.IsNullOrEmpty(captchaImage))
                {
                    ViewBag.error = "Captcha doğrulanmamış";
                    ViewBag.loginNumber = loginNumber;
                    return View("~/Views/FactoryUser/Login.cshtml");
                }

                var verified = await CheckCaptcha();
                if (!verified)
                {
                    ViewBag.error = "Captcha yanlış doğrulanmış";
                    ViewBag.loginNumber = loginNumber;
                    return View("~/Views/FactoryUser/Login.cshtml");
                }
            }

            Seller loginUser = _context.Sellers.FirstOrDefault(x => x.sellerEmail == user.factoryUserEmail);
            if (loginUser == null)
            {
                ViewBag.error = "Böyle bir kullanıcı kayıtlı değil";
                loginNumber++;
                ViewBag.loginNumber = loginNumber;
                HttpContext.Session.SetInt32("loginNumber", loginNumber);
                return View("~/Views/FactoryUser/Login.cshtml");
            }
            if (loginUser.sellerPassword == Crypto.Hash(user.factoryUserPassword, "MD5"))
            {
                HttpContext.Session.Clear();
                HttpContext.Session.SetInt32("isFactory", 0);
                HttpContext.Session.SetInt32("userId", loginUser.sellerId);
                HttpContext.Session.SetString("userEmail", loginUser.sellerEmail);
                HttpContext.Session.SetString("userName", loginUser.sellerName);
                return RedirectToAction("IndexForSeller", "Product");
            }
            ViewBag.error = "Yanlış Şifre";
            loginNumber++;
            ViewBag.loginNumber = loginNumber;
            HttpContext.Session.SetInt32("loginNumber", loginNumber);
            return View("~/Views/FactoryUser/Login.cshtml");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View("~/Views/FactoryUser/ForgotPassword.cshtml");
        }

        [HttpPost]
        public IActionResult ForgotPassword(string userEmail)
        {
            Seller user = _context.Sellers.FirstOrDefault(x => x.sellerEmail == userEmail);
            if (user == null)
            {
                ViewBag.error = "Email adresi yanlış veya böyle bir kullanıcı kayıtlı değil!";
            }
            else
            {
                Random rnd = new Random();
                var number = rnd.Next();
                var newPassword = Crypto.Hash(number.ToString(), "MD5");
                user.sellerPassword = newPassword;
                _context.SaveChanges();

                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("abbadabaka@gmail.com"));
                email.To.Add(MailboxAddress.Parse(user.sellerEmail));
                email.Subject = "Şifre Yenileme";
                email.Body = new TextPart(TextFormat.Plain) { Text = "Sayın '" + user.sellerName + "', Yeni Şifreniz: " + number };

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("abbadabaka@gmail.com", "asdfgh1346");
                smtp.Send(email);
                smtp.Disconnect(true);
                ViewBag.error = "Yeni şifreniz Email adresinize gönderildi!";
            }
            return View("~/Views/FactoryUser/ForgotPassword.cshtml");
        }
        private async Task<bool> CheckCaptcha()
        {
            var postData = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("secret", "6Lfn2i4aAAAAAKAYc_UBCouscCWuDHIa_BkvsUNR"),
                new KeyValuePair<string, string>("remoteip", HttpContext.Connection.RemoteIpAddress.ToString()),
                new KeyValuePair<string, string>("response", HttpContext.Request.Form["g-recaptcha-response"])
            };

            var client = new HttpClient();
            var response = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", new FormUrlEncodedContent(postData));

            var o = (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());

            return (bool)o["success"];
        }
    }
}
