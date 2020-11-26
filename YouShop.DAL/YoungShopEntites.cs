using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouShop.DAL
{
    public class YoungShopEntites : DbContext
    {
        public YoungShopEntites() : base("YoungShop")
        {

        }
    }
}
