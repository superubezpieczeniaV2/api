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
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }
        public string Id { get; set; }

        [ForeignKey("Id")]
        public virtual User User { get; set; }
    }
}
