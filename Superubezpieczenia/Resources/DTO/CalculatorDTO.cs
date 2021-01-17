using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Persistence.Repositories
{
    public class CalculatorDTO
    {
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int IDEnginePower { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int IDMark { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int IDMethodUse { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int IDModel { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int IDParkingPlace { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int IDTypeInsurance { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int IDTypeOwner { get; set; }
    }
}
