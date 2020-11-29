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
    public class HomeController : Controller
    {
        readonly UserBLL UserBLL = new UserBLL();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Sigin()
        {
            if (Session["User"] != null)
                return Redirect("/Home/Index");

            var ranString = new Random(Guid.NewGuid().GetHashCode());
            string code = ranString.Next(1000, 9999).ToString();
            var AuthCode = ImgCode.Get(code);
            Session["code"] = code;

            if (AuthCode.Contains("/Code/"))
            {
                Session["Error"] = null;
                Session["AuthCode"] = AuthCode;
            }
            else
            {
                Session["Error"] = AuthCode;
            }

            return View();
        }
        [HttpPost]
        public ActionResult Sigin(Sigin sigin)
        {
            if (Request["AuthCode"] == Session["code"].ToString())
            {
                if (sigin.Account != null && sigin.Password != null)
                {
                    sigin.Password = Security.MD5Encrypt32(sigin.Password);
                    var mod = UserBLL.GetSign(sigin);
                    if (mod != null)
                    {
                        Session["User"] = mod;
                        return Content("success");
                    }
                    else
                    {
                        return Content("账号或密码错误");
                    }
                }
                else
                {
                    return Content("不允许为空");
                }
            }
            else
            {
                return Content("验证码错误");
            }
        }
        /// <summary>
        /// 刷新验证码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetCode()
        {
            var ranString = new Random(Guid.NewGuid().GetHashCode());
            string code = ranString.Next(1000, 9999).ToString();
            var AuthCode = ImgCode.Get(code);
            Session["code"] = code;

            Session["AuthCode"] = AuthCode;
            return Content(AuthCode);
        }
    }
}