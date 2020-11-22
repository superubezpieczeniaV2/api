﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class Model
    {
        [Key]
        public int IDModel { get; set; }
        public int IDMark { get; set; }
        public string Name { get; set; }

        [ForeignKey("IDMark")]
        public virtual Mark Mark { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
