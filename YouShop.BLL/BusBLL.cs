using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouShop.Model;

namespace YouShop.BLL
{
   public class BusBLL
    {
        private DAL.YoungShopEntites _ef;
        public DAL.YoungShopEntites EF
        {
            get
            {
                if (_ef == null)
                    _ef = new DAL.YoungShopEntites();
                return _ef;
            }
        }
       //查询商家信息
        public Model.Sigin Merchants(int id)
 {
            var list = EF.Sigins.Include("User").Include("Stars").Include("Sends").Include("Addresses").Include("Coments").FirstOrDefault(x=>x.ID==id);
            return list;
        }
        //查询商品信息
        public List<Model.Coment> GetComent(int Sid)
        {
            var SP = EF.Coments.Include("Shop").Where(x => x.SiginID == Sid);
            return SP;
        }
    }
}
