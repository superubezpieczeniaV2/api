using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class PolicyDetails
    {
        [Key]
        public int IDPolicyDetails { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public int IDTypeInsurance { get; set; }
        [Required]
        public int IDModel { get; set; }
        [Required]
        public int IDTypeOwner { get; set; }
        [Required]
        public DateTime YearProduction { get; set; }
        [Required]
        public int IDTypeFuel { get; set; }
        [Required]
        public int IDEnginePower { get; set; }
        [Required]
        public Boolean LocationDriver { get; set; }
        public DateTime FirstRegistration { get; set; }
        [Required]
        public string PlannedMileage { get; set; }
        [Required]
        public int IDMethodUse { get; set; }
        [Required]
        public int IDParkingPlace { get; set; }
        [Required]
        public Boolean BroughtBack { get; set; }
        [Required]
        public DateTime SinceWhenInsurance { get; set; }
        public int ExtraDrivers { get; set; }
        public int CurrentMileage { get; set; }
        [ForeignKey("IDTypeInsurance")]
        public virtual TypeInsurance TypesInsurance { get; set; }
        [ForeignKey("IDModel")]
        public virtual Model Model { get; set; }
        [ForeignKey("IDTypeOwner")]
        public virtual TypeOwner TypeOwner { get; set; }
        [ForeignKey("IDTypeFuel")]
        public virtual TypeFuel TypeFuel { get; set; }
        [ForeignKey("IDEnginePower")]
        public virtual EnginePower EnginePower { get; set; }
        [ForeignKey("IDMethodUse")]
        public virtual MethodUse MethodUse { get; set; }
        [ForeignKey("IDParkingPlace")]
        public virtual ParkingPlace ParkingPlace { get; set; }
        
        

    }
}
