using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YouShop.Model
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public string ShopPath { get; set; }
        public string ExpessNumber { get; set; }
        public int Status { get; set; }
        public int PayID { get; set; }
        public int UserID { set; get; }
        public int? CouponID { set; get; }
        public DateTime EntryTime { get; set; }

        [ForeignKey("PayID")]
        public Pay Pay { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }

        [ForeignKey("CouponID")]
        public Coupon Coupon { get; set; }
    }
}