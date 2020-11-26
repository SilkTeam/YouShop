using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouShop.Model
{
    public class Wallet
    {
        [Key]
        public int ID { set; get; }
        public string Money { set; get; }
        public List<User> Users { set; get; }
    }
}