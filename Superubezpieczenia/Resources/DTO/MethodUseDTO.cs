using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Resources.DTO
{
    public class MethodUseDTO
    {
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public string Method { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public double Value { get; set; }
    }
}
