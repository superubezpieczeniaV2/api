using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class EnginePower
    {
        [Key]
        public int IDEnginePower { get; set; }
        [Required]
        public double Power { get; set; }
        [Required]
        public double Capacity { get; set; }
        [Required]
        public double Value { get; set; }
        
    }
}
