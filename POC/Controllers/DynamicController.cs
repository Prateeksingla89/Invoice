using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POC.Controllers
{
    public class DynamicController : Controller
    {
        public class DynamicController1
        {

        }
        // GET: Dynamic
        public ActionResult DynamicRow(DynamicController1 test )
        {
            return View();
        }
    }
}