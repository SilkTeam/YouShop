using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using YouShop.Model;

namespace YouShop.Model

{
    public class MyCar
    {
        [Key]
        public int ID { get; set; }
        public int ShopID { get; set; }
        public int SiginID { get; set; }

        [ForeignKey("ShopID")]
        public Shop Shop { get; set; }

        [ForeignKey("SiginID")]
        public Sigin Sigin { get; set; }
    }
}