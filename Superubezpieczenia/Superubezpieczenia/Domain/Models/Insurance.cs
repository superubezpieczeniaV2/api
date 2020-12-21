using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class Insurance
    {
        [Key]
        public int IDInsurance { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string IDUser { get; set; }

        [ForeignKey("IDUser")]
        public virtual User User { get; set; }
    }
}
