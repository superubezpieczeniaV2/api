using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class UserRoles
    {
        [Key]
        public int IDUserPermission { get; set; }
        public int IDUser { get; set; }
        public int IDPermission { get; set; }
        [ForeignKey("IDUser")]
        public virtual User User { get; set; }
        [ForeignKey("IDPermission")]
        public virtual Permission Permission { get; set; }

    }
}
