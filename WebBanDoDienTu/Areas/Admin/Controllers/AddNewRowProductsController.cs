using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanDoDienTu.Areas.Admin.Controllers
{
    [Area("admin")]
    public class AddNewRowProductsController : Controller
    {
        // GET: AddNewRowUsersController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AddNewRowUsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AddNewRowUsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddNewRowUsersController/Create
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

        // GET: AddNewRowUsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AddNewRowUsersController/Edit/5
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

        // GET: AddNewRowUsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddNewRowUsersController/Delete/5
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
