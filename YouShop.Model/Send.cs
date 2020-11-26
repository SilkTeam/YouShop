using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouShop.Model
{
    public class Send
    {
        [Key]
        public int ID { get; set; }
        public int SiginID { get; set; }
        public string Type { get; set; }
        public bool Status { get; set; }
        public DateTime EntyTime { get; set; }

        [ForeignKey("SiginID")]
        public Sigin Sigin { set; get; }
    }
}
