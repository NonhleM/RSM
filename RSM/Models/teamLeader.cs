using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSM.Models
{
    public class teamLeader
    {
        [Key]
        public int teamleader_ID { get; set; }

        //Navigation properties
        public team team { get; set; }
        public user user { get; set; }
    }
}
