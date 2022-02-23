using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanDoDienTu.Common;
using WebBanDoDienTu.Models;

namespace WebBanDoDienTu.Controllers
{
    public class SearchController : Controller
    {
        private BANDODIENTUContext _db = new BANDODIENTUContext();
        // GET: SearchController
        public ActionResult Index()
        {

            
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
        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart") != null)
            {
                ViewBag.cartCount = Count();
                var cart = SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);

            }
            ViewData["Email"] = SessionHelper.GetComplexData<string>(HttpContext.Session, "Email");
            ViewData["Role"] = SessionHelper.GetComplexData<string>(HttpContext.Session, "Role");
            ProductModel productModel = new ProductModel();
            ViewData["product"] = productModel.FindAll();
            ViewBag.userid = SessionHelper.GetComplexData<int>(HttpContext.Session, "UserID");
            return View(_db.Product.Where(x=>x.Name.Contains(searchString)).ToList());
        }
        // GET: SearchController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SearchController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SearchController/Create
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

        // GET: SearchController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SearchController/Edit/5
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

        // GET: SearchController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SearchController/Delete/5
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
