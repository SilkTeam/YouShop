using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YouShop.Model
{
    public class Shop
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public int SortID { get; set; }
        public bool Status { get; set; }
        public double Price { get; set; }
        public double Off { get; set; }
        public DateTime EntryTime { get; set; }
        public List<Star> Stars { get; set; }

        [ForeignKey("SortID")]
        public Sort Sort { get; set; }
        public List<Coment> Coments { set; get; }
        public List<MyCar> MyCars { set; get; }
    }
}