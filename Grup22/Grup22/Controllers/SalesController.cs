using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Grup22.Context;
using Grup22.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grup22.Controllers
{
    public class SalesController : Controller
    {
        private readonly KurumsalContext _context;

        public SalesController(KurumsalContext context)
        {
            _context = context;
        }

        public IActionResult ShowOrders()
        {
            //Bayi, oluşturduğu mevcut siparişlerini görür.
            if (HttpContext.Session.GetInt32("isFactory") == 0)
            {
                var orderInformations = _context.ProductSalesRecords.Where(w => w.salesRecordConfirmation == false && w.sellerId == HttpContext.Session.GetInt32("userId")).Join(_context.Products, record => record.productId, product => product.productId,
                    (record, product) => Tuple.Create(record, product)).ToList();
                return View(orderInformations);
            }
            //Fabrika, bayisinin sipariş ettiği ve geri dönüş yapmadığı sipariş bilgilerini görür.
            else if (HttpContext.Session.GetInt32("isFactory") == 1)
            {
                var orderInformations = _context.ProductSalesRecords.Where(w => w.salesRecordConfirmation == false && w.salesRecordProduct.factoryUserId == HttpContext.Session.GetInt32("userId")).Join(_context.Products, record => record.productId, product => product.productId,
                    (record, product) => Tuple.Create(record, product)).ToList();
                return View(orderInformations);
            }
            else
            {
                var EmptyRecords = _context.ProductSalesRecords.Where(x => x.salesRecordId == 0);
                return View(EmptyRecords.ToList());
            }
        }

        public IActionResult CreateOrder(int id)
        {
            Product product = _context.Products.Include(x => x.productFactoryUser).FirstOrDefault(y => y.productId == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult CreateOrder(int saleProductId, int amountRequested)
        {
            Product _product = _context.Products.Find(saleProductId);
            if (amountRequested == 0)
                ViewBag.error = "0 ürün sipariş edilemez.";
            else if (amountRequested < 50)
                ViewBag.error = "50'den az ürün sipariş edilemez.";
            else if (amountRequested <= _product.productStock)
            {
                ProductSalesRecord newSalesRecord = new ProductSalesRecord();
                newSalesRecord.productId = saleProductId;
                newSalesRecord.salesRecordAmount = amountRequested;
                newSalesRecord.salesRecordConfirmation = false;
                newSalesRecord.salesRecordProduct = _context.Products.Find(saleProductId);
                newSalesRecord.sellerId = (int)HttpContext.Session.GetInt32("userId");
                newSalesRecord.orderCreationDate = DateTime.Now;
                _context.ProductSalesRecords.Add(newSalesRecord);
                _context.SaveChanges();
                return RedirectToAction(nameof(ShowOrders));
            }
            else
                ViewBag.error = "Stokta istenen miktarda ürün bulunmamaktadır.";
            return View(_product);
        }

        [HttpGet]
        public IActionResult EditOrder(int id)
        {
            ProductSalesRecord editRecord = _context.ProductSalesRecords.Find(id);
            Product _product = _context.Products.Find(editRecord.productId);
            ViewBag.name = _product.productName;
            ViewBag.totalPrice = Math.Round(Convert.ToDecimal(_product.productPrice * editRecord.salesRecordAmount), 2);
            return View(editRecord);
        }

        [HttpPost]
        public IActionResult EditOrder(ProductSalesRecord salesRecord)
        {
            Product _product = _context.Products.Find(salesRecord.productId);
            if (salesRecord.salesRecordAmount == 0)
                ViewBag.error = "0 ürün sipariş edilemez.";
            else if (salesRecord.salesRecordAmount < 50)
                ViewBag.error = "50'den az ürün sipariş edilemez.";
            else if (salesRecord.salesRecordAmount <= _product.productStock)
            {
                //_context.ProductSalesRecords.Update(editRecord);
                ProductSalesRecord editRecord = _context.ProductSalesRecords.Find(salesRecord.salesRecordId);
                editRecord.salesRecordAmount = salesRecord.salesRecordAmount;
                _context.SaveChanges();
                return RedirectToAction(nameof(ShowOrders));
            }
            else
                ViewBag.error = "Stokta istenen miktarda ürün bulunmamaktadır.";
            return View(salesRecord);
        }

        public IActionResult DeleteOrder(int id)
        {
            var deletedRecord = _context.ProductSalesRecords.Find(id);
            _context.ProductSalesRecords.Remove(deletedRecord);
            _context.SaveChanges();
            return RedirectToAction(nameof(ShowOrders));
        }

        [HttpPost]
        public IActionResult DetailOrder(ProductSalesRecord salesRecord)
        {
            //_context.ProductSalesRecords.Update(salesRecord);
            ProductSalesRecord editRecord = _context.ProductSalesRecords.Find(salesRecord.salesRecordId);
            editRecord.salesRecordAmount = salesRecord.salesRecordAmount;
            _context.SaveChanges();
            return RedirectToAction(nameof(ShowOrders));
        }

        public IActionResult AcceptOrder(int id)
        {
            ProductSalesRecord acceptedRecord = _context.ProductSalesRecords.Find(id);
            acceptedRecord.salesRecordConfirmation = true;
            acceptedRecord.orderCompletionDate = DateTime.Now;
            Product _product = _context.Products.Find(acceptedRecord.productId);
            _product.productStock = _product.productStock - acceptedRecord.salesRecordAmount;
            _context.SaveChanges();
            return RedirectToAction(nameof(ShowOrders));
        }

        public IActionResult RejectOrder(int id)
        {
            ProductSalesRecord salesRecord = _context.ProductSalesRecords.Find(id);
            _context.ProductSalesRecords.Remove(salesRecord);
            _context.SaveChanges();
            return RedirectToAction(nameof(ShowOrders));
        }
        public IActionResult IndexSalesRecords()
        {
            if (HttpContext.Session.GetInt32("isFactory") == 0)
            {
                var index = _context.ProductSalesRecords.Where(w => w.salesRecordConfirmation == true && w.sellerId == HttpContext.Session.GetInt32("userId")).Join(_context.Products.Include(i => i.productFactoryUser), record => record.productId, product => product.productId,
                    (record, product) => Tuple.Create(record, product)).ToList();
                return View(index);
            }
            else if (HttpContext.Session.GetInt32("isFactory") == 1)
            {
                var index = _context.ProductSalesRecords.Where(w => w.salesRecordConfirmation == true && w.salesRecordProduct.factoryUserId == HttpContext.Session.GetInt32("userId")).Join(_context.Products.Include(i => i.productFactoryUser), record => record.productId, product => product.productId,
                    (record, product) => Tuple.Create(record, product)).ToList();
                return View(index);
            }
            else
            {
                var index = _context.ProductSalesRecords.Where(w => w.salesRecordId == 0);
                return View(index.ToList());
            }
        }
    }
}
