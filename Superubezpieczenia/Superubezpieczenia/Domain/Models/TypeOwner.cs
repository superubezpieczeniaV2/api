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
        public string Type { get; set; }
        public double Value { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
