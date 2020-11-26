using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouShop.Model
{
    public class Sigin
    {
        [Key]
        public int ID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string qq_openid { get; set; }
        public string wx_openid { get; set; }
        public string Identity { get; set; }
    }
}
