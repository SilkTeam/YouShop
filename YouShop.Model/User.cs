using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouShop.Model
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public string Img { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int WalletID { get; set; }
        public DateTime EntryTime { get; set; }
        public int SiginID { get; set; }

        [ForeignKey("WalletID")]
        public Wallet Wallet { set; get; }

        [ForeignKey("SiginID")]
        public Sigin Sigin { set; get; }
    }
}