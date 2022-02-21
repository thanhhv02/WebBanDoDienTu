using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebBanDoDienTu.Common;
using WebBanDoDienTu.Models;

namespace WebBanDoDienTu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart") != null)
            {
                ViewBag.cartCount = Count();
                var cart = SessionHelper.GetComplexData<List<Item>>(HttpContext.Session, "cart");
                ViewBag.cart = cart;
            }
            ViewData["Email"] = SessionHelper.GetComplexData<string>(HttpContext.Session, "Email");
            ViewData["Role"] = SessionHelper.GetComplexData<string>(HttpContext.Session, "Role");
            ProductModel productModel = new ProductModel();
            ViewData["product"] = productModel.FindAll();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
