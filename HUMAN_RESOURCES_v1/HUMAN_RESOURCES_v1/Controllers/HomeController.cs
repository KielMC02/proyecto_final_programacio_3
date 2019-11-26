using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HUMAN_RESOURCES_v1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Bienvenida()
        {
            return View();
        }
    }
}