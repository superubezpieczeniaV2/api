using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class Log
    {
        [Key]
        public int IDLogger { get; set; }
        public string ControllerName { get; set; }
        public string UserName { get; set; }
        public string ActionName { get; set; }
        public DateTime DataLog { get; set; }
    }
}
