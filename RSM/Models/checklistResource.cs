using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSM.Models
{
    public class checklistResource
    {
        [Key]
        public int checklistresource_ID { get; set; }

        //Navigation properties
        public checklist checklist { get; set; }
        public resource resource { get; set; }
    }
}
