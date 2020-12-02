﻿using System;
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
        public int Type { get; set; }
        public virtual ICollection<PolicyDetails> Policies { get; set; }
    }
}
