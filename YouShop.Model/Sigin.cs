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
        public List<User> Users { get; set; }
        public List<Star> Stars { get; set; }
        public List<Send> Sends { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Coment> Coments { get; set; }
        public List<MyCar> MyCars { get; set; }
    }
}
