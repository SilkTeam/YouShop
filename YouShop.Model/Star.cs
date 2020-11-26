using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YouShop.Model
{
    public class Star
    {
        [Key]
        public int ID { set; get; }
        public int SiginID { get; set; }
        public int ShopID { get; set; }
        public DateTime EntryTime { set; get; }

        [ForeignKey("SiginID")]
        public Sigin Sigin { set; get; }

        [ForeignKey("ShopID")]
        public Shop Shop { set; get; }
    }
}