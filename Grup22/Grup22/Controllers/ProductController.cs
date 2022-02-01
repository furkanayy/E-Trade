using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Grup22.Context;
using Grup22.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Web.Helpers;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.ComponentModel;
using Microsoft.AspNetCore.Hosting;

namespace Grup22.Controllers
{
    public class ProductController : Controller
    {
        //Veritabanı bağlantısı için context sınıfına ulaşıyoruz
        private readonly KurumsalContext _context;
        //Dosya yolunu bulabilmek için
        private IWebHostEnvironment _hostingEnvironment;

        public ProductController(KurumsalContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _hostingEnvironment = environment;
        }

        //Bu Action, Fabrika'nın kullanacağı ürün listeleme sayfasına yönlendirir.
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("isFactory") == 1)
            {
                //Veritabanından fabrikanın kendi ürünleri aranıyor ve View'a gönderiliyor.
                //var kurumsalContext = _context.Products.Include(p => p.productFactoryUser).Where(x => x.productFactoryUser.factoryUserId == HttpContext.Session.GetInt32("userId"));
                var kurumsalContext = _context.Products.FromSqlRaw($"getProduct {HttpContext.Session.GetInt32("userId")}");
                return View(await kurumsalContext.ToListAsync());
            }
            //İçeride tekrardan bayi veya fabrika sorgusu yapılıyor tedbir olarak. Eğer bayi bu sayfayı açmaya çalışırsa kendi için hazırlanan Action'a yönlendiriliyor.
            else if (HttpContext.Session.GetInt32("isFactory") == 0)
                return RedirectToAction(nameof(IndexForSeller));
            else
            {
                //Oturum açılmamışsa boş bir liste döndürülüyor.
                var emptyContext = _context.Products.Where(x => x.factoryUserId == 0);
                return View(emptyContext.ToList());
            }
        }

        //Bu Action, Bayinin'ın kullanacağı ürün listeleme sayfasına yönlendirir.
        public async Task<IActionResult> IndexForSeller()
        {
            if (HttpContext.Session.GetInt32("isFactory") == 0)
            {
                //Sisteme giriş yapmış olan bayinin bağlı olduğu fabrikanın ürünleri veritabanında bulunuyor.
                var kurumsalContext = _context.Products.Include(p => p.productFactoryUser).Where(x => x.productFactoryUser.factoryUserId == _context.Sellers.Include(s => s.sellerFactoryUser).FirstOrDefault(i => i.sellerId == HttpContext.Session.GetInt32("userId")).sellerFactoryUser.factoryUserId);
                return View(await kurumsalContext.ToListAsync());
            }
            else if(HttpContext.Session.GetInt32("isFactory") == 1)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var emptyContext = _context.Products.Where(x => x.factoryUserId == 0);
                return View(emptyContext.ToList());
            }
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("userId") == null || HttpContext.Session.GetInt32("isFactory") == 0)
                return RedirectToAction(nameof(Index));
            else
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productId,productName,productDescription,productStock,productPrice,productImageUrl")] Product product, IFormFile uploadImage)
        {
            if (ModelState.IsValid)
            {   
                try
                {
                    if (uploadImage != null)
                    {
                        product.productImageUrl = SaveImage(uploadImage);
                    }
                    //Ürünün hangi fabrikaya ait olduğu, sisteme daha önceden giriş yapan kullanıcının session bilgileri kullanılarak veritabanına kaydedilir.
                    product.factoryUserId = (int)HttpContext.Session.GetInt32("userId");
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.productId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (UnknownImageFormatException)
                {
                    ViewBag.message = "Lütfen .png veya .jpeg formatında resim yükleyiniz.";
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.productFactoryUser)
                .FirstOrDefaultAsync(m => m.productId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        
        // ürün düzenleme
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productId,productName,productDescription,productStock,productPrice")] Product product,IFormFile uploadImage)
        {
            if (id != product.productId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Product editproduct = _context.Products.Find(id);
                    DeleteImage(editproduct);
                    if (uploadImage != null)
                    {
                        editproduct.productImageUrl = SaveImage(uploadImage);
                    }
                    editproduct.productName = product.productName;
                    editproduct.productDescription = product.productDescription;
                    editproduct.productPrice = product.productPrice;
                    editproduct.productStock = product.productStock;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.productId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (UnknownImageFormatException)
                {
                    ViewBag.message = "Lütfen .png veya .jpeg formatında resim yükleyiniz.";
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // ürün silme işlemi
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.productFactoryUser)
                .FirstOrDefaultAsync(m => m.productId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // ürün silme onaylama endpointi
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            DeleteImage(product);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Formda yüklenen resim belirlenen klasöre yeniden isimlendirilerek kaydedilir.
        //Aynı zamanda resmin url'si veritabanında ürünü nesnesinin ilgili sütununa kaydedilir.
        public string SaveImage(IFormFile uploadImage)
        {
            using var image = Image.Load(uploadImage.OpenReadStream());
            FileInfo info = new FileInfo(uploadImage.FileName);
            image.Mutate(x => x.Resize(200, 200));
            string logoname = Guid.NewGuid().ToString() + info.Extension;
            image.Save("../Grup22/wwwroot/Images/" + logoname);
            return "/Images/" + logoname;
        }

        //Söz konusu ürünün fotoğrafının bulunduğu yeri bulup silme işini yapan fonksiyon
        public void DeleteImage(Product product)
        {
            if (System.IO.File.Exists(Path.Combine(_hostingEnvironment.WebRootPath + product.productImageUrl)))
            { System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath + product.productImageUrl)); }
        }
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.productId == id);
        }
    }
}
