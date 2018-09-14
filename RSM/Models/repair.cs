using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSM.Models
{
    public class repair
    {
        [Key]
       public int repair_ID { get; set; }
        public string repair_description { get; set; }
        public string repair_prioritystatus { get; set; }
        public string repair_completionstatus { get; set; }
        public DateTime repair_createddate { get; set; }

        






    }
}
