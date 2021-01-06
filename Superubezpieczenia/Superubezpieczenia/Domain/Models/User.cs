using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class User : IdentityUser
    {
        public static object Identity { get; internal set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
