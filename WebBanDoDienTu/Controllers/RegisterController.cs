using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class RegisterController : Controller
    {
        private BANDODIENTUContext _db = new BANDODIENTUContext();
        public RegisterController(BANDODIENTUContext db)
        {
            _db = db;
        }
        // GET: RegisterController
        public ActionResult Register()
        {
            ViewData["Email"] = SessionHelper.GetComplexData<string>(HttpContext.Session, "Email");
            return View();
        }
        [HttpPost]
        public ActionResult Register(string name, string email, string password)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(password))
            {
                ViewBag.nullename = "Nhập tên";
                return View();
            }
            else if (string.IsNullOrEmpty(email))
            {
                ViewBag.nullemail = "Nhập email";
                return View();
            }
            else if (string.IsNullOrEmpty(password))
            {
                ViewBag.nullpassword = "Nhập password";
                return View();
            }
            else
            {
                var cus = _db.Customers.Select(b => b).Where(b => b.Email == email).FirstOrDefault();
                if (cus != null)
                {
                    ViewBag.errorRegisEmail = "Email đã tồn tại";
                }
                else
                {
                    ViewBag.nullename = null;
                    ViewBag.nullemail = null;
                    ViewBag.nullpassword = null;
                    var customers = new Customers
                    {
                        Name = name,
                        Email = email,
                        Password = GetMD5(password),
                        CreatedBy = email
                    };
                    _db.Customers.Add(customers);
                    _db.SaveChangesAsync();
                    ViewBag.succesRegis = "Đăng ký thành công";
                }
            }
            
            return View();
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

        // GET: RegisterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegisterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterController/Create
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

        // GET: RegisterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegisterController/Edit/5
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

        // GET: RegisterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegisterController/Delete/5
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
