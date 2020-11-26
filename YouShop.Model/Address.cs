using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouShop.Model
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int SiginID { set; get; }

        [ForeignKey("SinigID")]
        public Sigin Sigin { set; get; }
    }
}