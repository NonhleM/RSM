using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSM.Models
{
    public class task
    {
        [Key]
        public int task_ID { get; set; }
        public string task_name { get; set; }
        public string task_instructions { get; set; }
        public DateTime task_createdate { get; set; }
        public string task_prioritystatus { get; set; }
        public string task_completionstatus { get; set; }
        public DateTime task_duedate { get; set; }

        //navigation properties
        public service service { get; set; }
        public user user { get; set; }


    }
}
