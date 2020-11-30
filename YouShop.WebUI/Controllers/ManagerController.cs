using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouShop.BLL;
using YouShop.Model;
using YouShop.WebUI.Handles;

namespace YouShop.WebUI.Controllers
{
    public class ManagerController : Controller
    {
        // GET: Manager

        readonly UserBLL UserBLL = new UserBLL();


        public YouShop.BLL.MemberBll MemberBll = new YouShop.BLL.MemberBll();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult GetList(int page = 1, int limit = 5)
        {
            var list = MemberBll.GetUser(out int dataCount, page, limit).Select(x => new
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
            return Json(res);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Sigin sigin, User user)

        {
            if (UserBLL.FindUser(sigin.Account))
                return Content("用户名已存在");

            user.Name = "ys" + Security.MD5Encrypt16(sigin.Account).Substring(0, 8);
            sigin.Password = Security.MD5Encrypt32("123456");
            if (UserBLL.GetReg(sigin, user))
            {
                return Content("success");
            }
            else
            {
                return Content("添加错误");
            }
        }
    }
}