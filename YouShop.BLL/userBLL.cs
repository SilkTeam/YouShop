using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouShop.DAL;
using YouShop.Model;

namespace YouShop.BLL
{
    public class UserBLL
    {
        /// <summary>
        /// 初始化EF
        /// </summary>
        private YoungShopEntites _ef;
        private YoungShopEntites EF
        {
            get
            {
                if (_ef == null)
                    _ef = new YoungShopEntites();
                return _ef;
            }
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sigin"></param>
        /// <returns></returns>
        public Sigin GetSign(Sigin sigin)
        {
            return EF.Sigins.FirstOrDefault(x => x.Account == sigin.Account && x.Password == sigin.Password || x.QQ_OpenID == sigin.QQ_OpenID || x.WX_OpenID == sigin.WX_OpenID);
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sigin"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool GetReg(Sigin sigin, User user)
        {
            var member = new Sigin()
            {
                Account = sigin.Account,
                Password = sigin.Password,
                Users = new List<User>()
                {
                    new User()
                    {
                        Name = user.Name,
                        Img = null,
                        Sex = user.Sex,
                        Age = user.Age,
                        Phone = user.Phone,
                        Email = user.Email,
                        WalletID = null,
                        EntryTime = DateTime.Now,
                    },
                },
            };
            EF.Sigins.Add(member);
            return EF.SaveChanges() > 0;
        }
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="email"></param>
        /// <param name="sigin"></param>
        /// <returns></returns>
        public bool RestPWD(string email, Sigin sigin)
        {
            var mod = EF.Sigins.FirstOrDefault(x => x.Account == sigin.Account);
            if (mod != null)
            {
                var user = EF.Users.FirstOrDefault(x => x.SiginID == mod.ID);
                if (user.Email == email)
                {
                    mod.Password = sigin.Password;
                }
            }
            return EF.SaveChanges() > 0;
        }
    }
}
