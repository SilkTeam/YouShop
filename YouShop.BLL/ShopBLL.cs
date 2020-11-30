using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouShop.DAL;
using YouShop.Model;

namespace YouShop.BLL
{
    public class ShopBLL
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
        /// 所有商品
        /// </summary>
        /// <returns></returns>
        public List<Shop> GetShop()
        {
            return EF.Shops.ToList();
        }

        public List<Shop> GetSearch(Model.Shop shop)
        {
            var list = EF.Shops.Where(x => true);
            if (!string.IsNullOrEmpty(shop.Name))
               list= list.Where(x => x.Name.Contains(shop.Name));

            var aa = list.ToList().Select(x => new
            {
                x.ID,
                x.Name,
                x.Description,
                x.Img,
                x.Price,
            });
           return list.ToList();
        }
    }
}

