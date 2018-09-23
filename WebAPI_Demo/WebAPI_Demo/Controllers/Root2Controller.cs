using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPI_Demo.Controllers
{
    public class Root2Controller : Controller
    {
        // GET: Root2
        public ActionResult Index()
        {
            return View();
        }
    }
}