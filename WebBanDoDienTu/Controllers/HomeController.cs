using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        private readonly BANDODIENTUContext _context;

        public HomeController(ILogger<HomeController> logger,BANDODIENTUContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
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
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            return View(customers);
        }

        // POST: Admin/Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(long id, [Bind("Id,UserName,Name,Address,Email,Phone")] Customers customers)
        {
            if (id != customers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var cus = await _context.Customers.FindAsync(customers.Id);
                cus.Name = customers.Name;
                cus.UserName = customers.UserName;
                cus.Address = customers.Address;
                cus.Email = customers.Email;
                cus.Phone = customers.Phone;
                try
                {
                    _context.Update(customers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(cus.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return View(customers);
            }
            return View(customers);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private bool CustomersExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
