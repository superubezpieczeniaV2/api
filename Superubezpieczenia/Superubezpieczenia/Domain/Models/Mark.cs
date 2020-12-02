using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class Mark
    {
        [Key]
        public int IDMark { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public virtual ICollection<Model> Models { get; set; }
        public virtual ICollection<PolicyDetails> Policies { get; set; }
    }
}
