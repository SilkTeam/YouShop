using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YouShop.Model
{
    public class Pay
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Money { get; set; }
        public DateTime EntryTime { get; set; }
        public List<Order> Orders { get; set; }
    }
}