using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSM.Models
{
    public class orderItems
    {
        [Key]
        public int orderitem_ID { get; set; }

        //navigation properties
        public resource resource { get; set; }
        public order order { get; set; }
    }
}
