using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSM.Models
{
    public class resource
    {
        [Key]
        public int resource_ID { get; set; }
        public string resource_type { get; set; }
        public string resource_name { get; set; }
        public string resource_description { get; set; }
        public DateTime resource_datebought { get; set; }
        public DateTime resource_datecreated { get; set; }
        public DateTime resource_datelastmodified { get; set; }
        public string resource_conditionstatus { get; set; }
        public string resource_availabilitystatus { get; set; }
        public DateTime resource_bookedfordate { get; set; }

        
        


    }
}
