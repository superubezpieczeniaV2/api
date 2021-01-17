using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class TypeInsurance
    {
        [Key]
        public int IDTypeInsurance { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public double Price { get; set; }
        
    }
}
