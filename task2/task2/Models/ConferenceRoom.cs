using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace task2.Models
{
    public class ConferenceRoom
    {
        [Key]
        public int Number { get; set; }
        public int Capacity { get; set; }
        public bool Projector { get; set; }
    }
}
