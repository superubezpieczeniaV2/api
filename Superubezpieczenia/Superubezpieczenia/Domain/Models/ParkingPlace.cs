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
        public string Place { get; set; }
        public double value { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
