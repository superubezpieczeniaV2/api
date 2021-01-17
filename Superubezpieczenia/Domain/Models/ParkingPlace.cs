using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class ParkingPlace
    {
        [Key]
        public int IDParkingPlace { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public double Value { get; set; }
        
    }
}
