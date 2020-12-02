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
        public int IDenginePower { get; set; }
        public double Power { get; set; }
        public double Capacity { get; set; }
        public double Value { get; set; }
        public virtual ICollection<PolicyDetails> Policies { get; set; }
    }
}
