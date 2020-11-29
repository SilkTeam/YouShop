using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YouShop.WebUI.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager
      


        public YouShop.BLL.MemberBll MemberBll = new YouShop.BLL.MemberBll();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetIndex(int page = 1, int limit = 5)
        {
            int dataCont = 0;
            var list = MemberBll.GetUser(out dataCont, page, limit);
            var res = new
            {
                code = 0,
                msg = "",
                count = dataCont,
                data = list,

            };
            return Json(res, JsonRequestBehavior.AllowGet);


        }

        public ActionResult GetList(int page = 1, int limit = 15)
        {
            int dataCount = 0;
            var list = MemberBll.GetUser(out dataCount, page, limit).Select(x => new
            {

                x.Email,
                x.SiginID,
                x.WalletID,
                x.Phone,
                x.Img,
                x.ID,
                x.Name,
                x.EntryTime,
                x.Age,
                Sex = x.Sex == 1 ? "男" : "女",


            });
            var res = new
            {
                code = 0,
                msg = "",
                count = dataCount,
                data = list
            };

            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Add()

        {
            return View();

        }

        [HttpPost]
        public ActionResult Add( Model.User user)

        {

            var isOk = MemberBll.Add(user);
            return Json(isOk);

        }


    }
}