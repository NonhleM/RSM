using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSM.Models
{
    public class service
    {
        [Key]
       public int service_id { get; set; }
       public string service_name { get; set; }
       public string service_description { get; set; }
       public DateTime service_datetime { get; set; }
       public string service_venue { get; set; }
       public DateTime service_createddate { get; set; }

        //navigation properties
        public ICollection<task> task { get; set; }
        public ICollection<team> team { get; set; }





    }
}
