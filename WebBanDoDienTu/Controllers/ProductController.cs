using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanDoDienTu.Common;
using WebBanDoDienTu.Models;

namespace WebBanDoDienTu.Controllers
{
    public class ProductController : Controller
    {
        private BANDODIENTUContext db = new BANDODIENTUContext();
        // GET: ProductController
        public ActionResult Index()
        {
            if (SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart") != null)
            {
                ViewBag.cartCount = Count();
                var cart = SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
            }
            ViewData["Email"] = SessionHelper.GetComplexData<string>(HttpContext.Session, "Email");
            ProductModel productModel = new ProductModel();
            ViewData["product"] = productModel.FindAll();
            ViewData["Role"] = SessionHelper.GetComplexData<string>(HttpContext.Session, "Role");
            return View();
        }
        public int Count()
        {
            List<Item> cart = SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart");
            int count = 0;
            for (int i = 0; i < cart.Count; i++)
            {
                count++;
            }
            return count;
        }
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
