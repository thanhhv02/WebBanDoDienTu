using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBanDoDienTu.Controllers
{
    public class _404Controller : Controller
    {
        // GET: _404Controller
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
