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
using System.Web.Helpers;

namespace Grup22.Controllers
{
    public class SellerController : Controller
    {
        private readonly KurumsalContext _context;

        public SellerController(KurumsalContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("isFactory") == 1)
            {
                var kurumsalContext = _context.Sellers.FromSqlRaw($"getSeller {HttpContext.Session.GetInt32("userId")}");
                return View(await kurumsalContext.ToListAsync());
            }
            else
            {
                var emptyContext = _context.Sellers.Where(x => x.factoryUserId == 0);
                return View(emptyContext.ToList());
            }
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetInt32("userId") == null || HttpContext.Session.GetInt32("isFactory") == 0)
                return RedirectToAction(nameof(Index));
            ViewBag.Cities = _context.City;
            ViewBag.Towns = _context.Town;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("sellerId,sellerEmail,sellerPassword,sellerName,sellerOwnersName,sellerAdress")] Seller seller, string DrpCity, string DrpTown)
        {
            seller.factoryUserId = (int)HttpContext.Session.GetInt32("userId");
            seller.sellerPassword = Crypto.Hash(seller.sellerPassword, "MD5");
            City city = _context.City.Find(int.Parse(DrpCity));
            seller.sellerCityName = city.CityName;
            Town town = _context.Town.Find(int.Parse(DrpTown));
            seller.sellerTownName = town.TownName;
            _context.Add(seller);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                // view'a yönlendirme yapılacak
                return NotFound();
            }
            var seller = await _context.Sellers.FindAsync(id);
            if (seller == null)
            {
                // view'a yönlendirme yapılacak
                return NotFound();
            }
            ViewBag.Cities = _context.City;
            ViewBag.Towns = _context.Town;
            return View(seller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("sellerId,sellerEmail,sellerPassword,sellerName,sellerOwnersName,sellerAdress")] Seller seller, string DrpCity, string DrpTown)
        {
            if (id != seller.sellerId)
            {
                // view'a yönlendirme yapılacak
                return NotFound();
            }
            try
            {
                Seller editSeller = _context.Sellers.Find(id);
                editSeller.sellerEmail = seller.sellerEmail;
                if(seller.sellerPassword != editSeller.sellerPassword)
                    editSeller.sellerPassword = seller.sellerPassword = Crypto.Hash(seller.sellerPassword, "MD5");
                editSeller.sellerName = seller.sellerName;
                editSeller.sellerAdress = seller.sellerAdress;
                City city = _context.City.Find(int.Parse(DrpCity));
                editSeller.sellerCityName = city.CityName;
                Town town = _context.Town.Find(int.Parse(DrpTown));
                editSeller.sellerTownName = town.TownName;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(seller.sellerId))
                {
                    // view'a yönlendirme yapılacak
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                // view'a yönlendirme yapılacak
                return NotFound();
            }

            var seller = await _context.Sellers
                .Include(s => s.sellerFactoryUser)
                .FirstOrDefaultAsync(m => m.sellerId == id);
            if (seller == null)
            {
                // view'a yönlendirme yapılacak
                return NotFound();
            }

            return View(seller);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);
            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                // view'a yönlendirme yapılacak
                return NotFound();
            }

            var seller = await _context.Sellers
                .Include(s => s.sellerFactoryUser)
                .FirstOrDefaultAsync(m => m.sellerId == id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        private bool SellerExists(int id)
        {
        // varolan satıcılar var mı true false
            return _context.Sellers.Any(e => e.sellerId == id);
        }

        public JsonResult getTowns(int cityId)
        {
            var towns = (
                         from x in _context.Town
                         join y in _context.City on x.CityID equals y.CityID
                         where x.CityID == cityId
                         select new
                         {
                             text = x.TownName,
                             value = x.TownID.ToString()
                         }).ToList();
            return Json(towns);

        }
    }
}
