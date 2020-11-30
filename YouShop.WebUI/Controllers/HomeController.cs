using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouShop.BLL;
using YouShop.Model;
using YouShop.WebUI.Filter;
using YouShop.WebUI.Handles;

namespace YouShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        readonly UserBLL userBLL = new UserBLL();
        readonly ShopBLL shopBLL = new ShopBLL();
        public ActionResult Index()
        {
            return View(shopBLL.GetShop());
        }
        public ActionResult List()
        {
            return View(shopBLL.GetShop());
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Sigin()
        {
            CodeRef();

            return View();
        }
        [HttpPost]
        public ActionResult Sigin(Sigin sigin)
        {
            if (Request["AuthCode"] == Session["code"].ToString())
            {
                //sigin.QQ_OpenID = sigin.WX_OpenID = "0";
                sigin.Password = Security.MD5Encrypt32(sigin.Password);
                var mod = userBLL.GetSign(sigin);
                if (mod == null)
                    return Content("账号或密码错误");

                Session["User"] = mod;
                Session["ID"] = mod.ID;
                Session["Identity"] = mod.Identity;
                // 身份固定，不可切换页面，注册时可选商家或用户，申请一律在Send表
                switch (mod.Identity)
                {
                    case 0:
                        return Content("success");
                    case 1:
                        return Redirect("/Home/Redir");
                    default:
                        return Redirect("/Home/Index");
                }
            }
            else
            {
                return Content("验证码错误");
            }
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Register()
        {
            if (Session["User"] != null)
                return Redirect("/Home/Index");

            CodeRef();

            return View();
        }
        [HttpPost]
        public ActionResult Register(Sigin sigin, User user)
        {
            if (Request["AuthCode"] == Session["code"].ToString())
            {
                if (userBLL.FindUser(sigin.Account))
                    return Content("用户名已存在");

                user.Name = "ys" + Security.MD5Encrypt16(sigin.Account).Substring(0, 8);
                sigin.Password = Security.MD5Encrypt32(sigin.Password);
                if (userBLL.GetReg(sigin, user))
                {
                    return Content("success");
                }
                else
                {
                    return Content("注册失败，请重试");
                }
            }
            else
            {
                return Content("验证码错误");
            }
        }
        public bool CodeRef()
        {
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
            return true;
        }
        /// <summary>
        /// 刷新验证码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetCode()
        {
            CodeRef();
            return Content(Session["AuthCode"].ToString());
        }
        /// <summary>
        /// Forget Password
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Forget()
        {
            if (Session["User"] != null)
                return Redirect("/Home/Index");

            CodeRef();

            return View();
        }
        [HttpPost]
        public ActionResult Forget(string Email, Sigin sigin)
        {
            if (Request["AuthCode"] == Session["code"].ToString())
            {
                sigin.Password = Security.MD5Encrypt32(sigin.Password);
                if (userBLL.RestPWD(Email, sigin))
                {
                    return Content("success");
                }
                else
                {
                    return Content("重置密码失败，请重试");
                }
            }
            else
            {
                return Content("验证码错误");
            }
        }
        /// <summary>
        /// Logout user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Logout()
        {
            Session["User"] = Session["Identity"] = Session["ID"] = null;
            return Content("success");
        }
        [HttpGet]
        public ActionResult MyInfo()
        {
            return View(userBLL.GetInfo(Convert.ToInt32(Session["ID"])));
        }
    }
}