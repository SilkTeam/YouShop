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
        public string QQ_OpenID { get; set; }
        public string WX_OpenID { get; set; }
        public int Identity { get; set; }
    }
}
