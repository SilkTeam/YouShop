using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YouShop.Model
{
    public class Coment
    {
        [Key]
        public int ID { get; set; }
        public string Info { get; set; }
        public int ShopID { get; set; }
        public int SiginID { get; set; }
        public int ParentID { set; get; }
        public DateTime EntryTime { get; set; }

        [ForeignKey("ShopID")]
        public Shop Shop { get; set; }

        [ForeignKey("SiginID")]
        public Sigin Sigin { get; set; }
    }
}