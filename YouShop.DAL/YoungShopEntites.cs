using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouShop.Model;

namespace YouShop.DAL
{
    public class YoungShopEntites : DbContext
    {
        public YoungShopEntites() : base("YoungShop")
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Coment> Coments { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Express> Expresses { get; set; }
        public DbSet<MyCar> MyCars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pay> Pays { get; set; }
        public DbSet<Send> Sends { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Sigin> Sigins { get; set; }
        public DbSet<Sort> Sorts { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
