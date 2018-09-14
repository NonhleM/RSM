using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSM.Models
{
    public class order
    {
        [Key]
        public int order_id { get; set; }
        public string order_name { get; set; }
        public DateTime order_createddate { get; set; }
        public string order_status { get; set; }
        public string order_description { get; set; }
        public int order_quantity { get; set; }
        public string order_prioritystatus { get; set; }

        //Navigation Properties
        public ICollection<resource> resource { get; set; }
      




    }
}
