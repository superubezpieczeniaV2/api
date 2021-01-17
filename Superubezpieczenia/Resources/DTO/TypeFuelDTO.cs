using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Resources.DTO
{
    public class TypeFuelDTO
    {
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public string Type { get; set; }
    }
}
