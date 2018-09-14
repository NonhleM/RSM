using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSM.Models
{
    public class user
    {
        [Key]
       public int user_ID { get; set; }
       public string user_type { get; set; }
       public string user_firstname { get; set; }
       public string user_lastname { get; set; }
       public string user_emailaddress { get; set; }
       public string user_password { get; set;}
       public DateTime user_datecreated { get; set; }
       public string user_status { get; set; }

        //Navigation Properties
        public ICollection<task> task { get; set; }




    }
}
