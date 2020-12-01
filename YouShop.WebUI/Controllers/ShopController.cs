using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YouShop.WebUI.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Order()
        {
            return Redirect("/Shop/Search");
        }
        public ActionResult MyCar()
        {
            return Redirect("/Shop/Search");
        }
    }
}