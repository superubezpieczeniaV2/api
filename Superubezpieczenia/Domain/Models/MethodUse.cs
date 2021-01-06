﻿using System;
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
        [Required]
        public string Method { get; set; }
        [Required]
        public double Value { get; set; }
        

    }
}
