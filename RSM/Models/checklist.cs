using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSM.Models
{
    public class checklist
    {
        [Key]
        public int checklist_ID { get; set; }

        public string checklist_description { get; set; }

        public DateTime checklist_createddate { get; set; }

        //Navigation Properties 
        public ICollection<resource> resource { get; set; }



    }
}
