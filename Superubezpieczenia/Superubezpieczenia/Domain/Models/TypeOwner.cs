using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class TypeOwner
    {
        [Key]
        public int IDTypeOwner { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public double Value { get; set; }
        
    }
}
