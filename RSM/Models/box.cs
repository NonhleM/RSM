using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSM.Models
{
    public class box
    {
        [Key]
        public int box_id { get; set; }

        public string box_name { get; set; }

        public int box_row { get; set; }

        public int box_column { get; set; }

        public DateTime box_createddate { get; set; }

        //Navigation Properties
        public ICollection<resource> resource { get; set; }


    }
}
