﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBanDoDienTu.Common;
using WebBanDoDienTu.Models;

namespace WebBanDoDienTu.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        private BANDODIENTUContext _db = new BANDODIENTUContext();
        // GET: CartController
        public ActionResult Index()
        {
            ViewData["Email"] = SessionHelper.GetComplexData<string>(HttpContext.Session, "Email");
            if(ViewData["Email"] != null)
            {
                if (SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart") != null)
                {
                    ViewBag.cartCount = Count();
                    var cart = SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart");
                    ViewBag.cart = cart;
                    ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
                }
                ProductModel productModel = new ProductModel();
                ViewData["product"] = productModel.FindAll();
                ViewData["Role"] = SessionHelper.GetComplexData<string>(HttpContext.Session, "Role");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
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
        [Route("buy/{id}")]
        public ActionResult AddItem(long id)
        {
            ProductModel productModel = new ProductModel();
            if (SessionHelper.GetComplexData<List<Item>>(HttpContext.Session,"cart")==null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = productModel.Find(id), Quantity = 1});
                SessionHelper.SetComplexData(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if(index != -1)
                {
                    cart[index].Quantity += 1;
                }
                else
                {
                    cart.Add(new Item { Product = productModel.Find(id), Quantity = 1 });
                }
                SessionHelper.SetComplexData(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index", "Product");
        }
        [Route("remove/{id}")]
        public IActionResult Remove(long id)
        {
            List<Item> cart = SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetComplexData(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
        private int isExist(long id)
        {
            List<Item> cart = SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart");

            for(int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
        // GET: CartController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
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

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
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

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
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
