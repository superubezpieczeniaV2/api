using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Resources.DTO
{
    public class PolicyDetailsDTO
    {       
        
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int IDTypeInsurance { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int IDModel { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int IDTypeOwner { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public DateTime YearProduction { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int IDTypeFuel { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int IDEnginePower { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public Boolean LocationDriver { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public DateTime FirstRegistration { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public string PlannedMileage { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int IDMethodUse { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int IDParkingPlace { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public Boolean BroughtBack { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public DateTime SinceWhenInsurance { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int ExtraDrivers { get; set; }
        [Required(ErrorMessage = "Sprawdź czy poprawnie uzupełniłeś pole, wszystkie pola muszą być uzupełnione")]
        public int CurrentMileage { get; set; }

    }
}
