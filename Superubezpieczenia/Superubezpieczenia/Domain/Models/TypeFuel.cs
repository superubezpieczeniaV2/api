using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class TypeFuel
    {
        [Key]
        public int IDTypeFuel { get; set; }
        public string Type { get; set; }
        
    }
}
