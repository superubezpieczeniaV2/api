using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Resources.DTO
{
    public class EnginePowerDTO
    {
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public double Power { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public double Capacity { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public double Value { get; set; }
    }
}
