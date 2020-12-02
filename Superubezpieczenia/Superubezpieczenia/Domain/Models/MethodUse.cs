using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    
    public class MethodUse
    {
        [Key]
        public int IDMethodUse { get; set; }
        public string Method { get; set; }
        public double Value { get; set; }
        public virtual ICollection<PolicyDetails> Policies { get; set; }

    }
}
