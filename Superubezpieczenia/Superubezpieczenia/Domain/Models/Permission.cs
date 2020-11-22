using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class Permission
    {
        [Key]
        public int IDPermission { get; set; }
        public string Type { get; set; }
        public virtual ICollection<UserRoles> UserPermissions { get; set; }
    }
}
