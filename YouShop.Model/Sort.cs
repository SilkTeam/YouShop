using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouShop.Model
{
  public class Sort
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int ParentID { get; set; }
        public string Status { get; set; }
        public List<Shop> Shops { get; set; }
    }
}
