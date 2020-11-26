using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication2.Models
{
    public class Express
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int Status { get; set; }
        public DateTime UpdateTime { get; set; }
        public int ParentID { get; set; }
    }
}