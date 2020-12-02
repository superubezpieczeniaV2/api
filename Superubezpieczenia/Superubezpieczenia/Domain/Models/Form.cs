
using Superubezpieczenia.Authentication;
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
        public string IDUser { get; set; }
        public int IDPolicyDetails { get; set; }
        [ForeignKey("IDUser")]
        public virtual User User { get; set; }
        [ForeignKey("IDPolicyDetails")]
        public virtual PolicyDetails PolicyDetails { get; set; }
        public virtual ICollection<Insurance> Policies { get; set; }
    }
}
