using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YouShop.Model
{
    public class Coupon
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Off { get; set; }
        public int SiginID { get; set; }
        public DateTime LastTime { get; set; }
        public bool Status { get; set; }

        [ForeignKey("SiginID")]
        public Sigin Sigin { get; set; }
        public List<Order> Orders { get; set; }
    }
}