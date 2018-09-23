using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI_Demo.Controllers
{
    public class Root1controller : Controller
    {
        // GET: Root1controller
        public ActionResult Index()
        {
            return View();
        }
    }
}