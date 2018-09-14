using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSM.Models
{
    public class team
    {
        [Key]
       public int team_ID { get; set; }
       public string team_name { get; set; }
       public DateTime team_datecreated { get; set; }

        //navigation properties
       public ICollection<user> user { get; set; }
       public ICollection<box> box { get; set; }




    }
}
