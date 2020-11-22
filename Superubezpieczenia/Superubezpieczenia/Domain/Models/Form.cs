
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class Form
    {
        [Key]
        public int IDForm { get; set; }
        public int IDUser { get; set; }
        public int IDAuto { get; set; }
        [ForeignKey("IDUser")]
        public virtual User User { get; set; }
        [ForeignKey("IDAuto")]
        public virtual Car Car { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
    }
}
