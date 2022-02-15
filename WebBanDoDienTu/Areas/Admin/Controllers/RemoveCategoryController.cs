﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanDoDienTu.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RemoveCategoryController : Controller
    {
        // GET: RemoveController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RemoveController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RemoveController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RemoveController/Create
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

        // GET: RemoveController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RemoveController/Edit/5
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

        // GET: RemoveController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RemoveController/Delete/5
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
