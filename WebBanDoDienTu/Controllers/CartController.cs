using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
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
                if (ViewData["Email"] != null)
                {
                    
                    ProductModel productModel = new ProductModel();
                    ViewData["product"] = productModel.FindAll();
                    ViewData["Role"] = SessionHelper.GetComplexData<string>(HttpContext.Session, "Role");
                    if (SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart") != null)
                    {

                        var cart = SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart");
                        ViewBag.cart = cart;
                        ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
                        ViewBag.cartCount = Count();
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }
                return View();
            
            
        }
        public ActionResult Error()
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
        [HttpPost]
        public IActionResult Update(IFormCollection fc)
        {
            StringValues quantites;
            fc.TryGetValue("quantity", out quantites);
            List<Item> cart = SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = Convert.ToInt32(quantites[i]);
            }
            SessionHelper.SetComplexData(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }
        public ActionResult Purchase()
        {
            var cart2 = SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart");
            var total2 = cart2.Sum(item => item.Product.Price * item.Quantity);
            ViewBag.cart2 = cart2;
            ViewData["Email"] = SessionHelper.GetComplexData<string>(HttpContext.Session, "Email");
            if (ViewData["Email"] != null && ViewBag.cart2 !=null)
            {
                var IdOfUser = SessionHelper.GetComplexData<int>(HttpContext.Session, "UserID");
                var cartSession = JsonConvert.SerializeObject(cart2);
                

                var cart = new Cart
                {
                    ProductInfo = cartSession,
                    UserId = (long)IdOfUser,
                    Total = (double)total2
                };
                _db.Cart.Add(cart);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", "Home");

        }
        [Route("buy/{id}")]
        public ActionResult AddItem(long id, string quantity)
        {
            string quantityTmp = quantity != null ? quantity : "1";
            ProductModel productModel = new ProductModel();
            if (SessionHelper.GetComplexData<List<Item>>(HttpContext.Session,"cart")==null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = productModel.Find(id), Quantity = Convert.ToInt32(quantityTmp) });
                SessionHelper.SetComplexData(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if(index != -1)
                {
                    cart[index].Quantity += Convert.ToInt32(quantityTmp);
                }
                else
                {
                    cart.Add(new Item { Product = productModel.Find(id), Quantity = Convert.ToInt32(quantityTmp)});
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
            if(index != -1)
            {
                
                cart.RemoveAt(index);
                SessionHelper.SetComplexData(HttpContext.Session, "cart", cart);
            }
            else
            {
                SessionHelper.SetComplexData(HttpContext.Session, "cart", null);
            }
            
            return RedirectToAction("Index","Cart");
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
