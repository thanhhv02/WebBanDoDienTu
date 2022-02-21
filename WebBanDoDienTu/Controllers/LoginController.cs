using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebBanDoDienTu.Common;
using WebBanDoDienTu.Models;

namespace WebBanDoDienTu.Controllers
{
    public class LoginController : Controller
    {
        private BANDODIENTUContext _db = new BANDODIENTUContext();

        // GET: LoginController
        //[HttpGet]
        public IActionResult Login()
        {
            ViewData["Email"] = SessionHelper.GetComplexData<string>(HttpContext.Session, "Email");
            ViewBag.userid = SessionHelper.GetComplexData<int>(HttpContext.Session, "UserID");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel objUser)
        {
            ViewData["Email"] = SessionHelper.GetComplexData<string>(HttpContext.Session, "Email");
            if (ModelState.IsValid)
            {


                var f_password = GetMD5( objUser.Password);
                var data = _db.Customers.Where(s => s.Email.Equals(objUser.Email) && s.Password.Equals(f_password)).ToList();
                var role = _db.Customers.Where(s => s.Email.Equals(objUser.Email)).Select(s=>s.Status).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    SessionHelper.SetComplexData(HttpContext.Session, "Email", data.FirstOrDefault().Email);
                    SessionHelper.SetComplexData(HttpContext.Session, "Password", data.FirstOrDefault().Password);
                    SessionHelper.SetComplexData(HttpContext.Session, "UserID", FindID(objUser.Email)) ;
                    SessionHelper.SetComplexData(HttpContext.Session, "Role", role.FirstOrDefault() );
                    //Session["Email"] = data.FirstOrDefault().Email;
                    //Session["idUser"] = data.FirstOrDefault().idUser;
                    ViewBag.loginSucces = "Đăng nhập thành công";
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();

        }
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _db.Customers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }
        public int FindID(string email)
        {
                try
                {
                    int userId = (int)(from x in _db.Customers
                                  where x.Email == email
                                  select x.Id).FirstOrDefault();

                    if (userId > 0)
                    {
                        return userId;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch 
                {
                    // has more than one element
                }
                return 0;

        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public IActionResult About()
        {
            return View();
        }
        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Verify()
        {
            return View();
        }

        // POST: LoginController/Create
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

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
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

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
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
