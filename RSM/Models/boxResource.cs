using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSM.Models
{
    public class boxResource
    {
        [Key]
        public int boxresource_id { get; set; }

        //navigation properties
        public box box { get; set; }
        public resource resource { get; set; }
    }
}
