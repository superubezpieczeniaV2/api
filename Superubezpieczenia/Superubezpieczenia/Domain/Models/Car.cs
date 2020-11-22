using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class Car
    {
        [Key]
        public int IDAuto { get; set; }
        public int IDModel { get; set; }
        public int IDTypeOwner { get; set; }
        public DateTime YearProduction { get; set; }
        public int IDTypeFuel { get; set; }
        public int IDEnginePower { get; set; }
        public Boolean LocationDriver { get; set; }
        public DateTime FirstRegistration { get; set; }
        public string PlannedMileage { get; set; }
        public int IDMethodUse { get; set; }
        public int IDParkingPlace { get; set; }
        public Boolean BroughtBack { get; set; }
        public DateTime SinceWhenInsurance { get; set; }
        public int ExtraDrivers { get; set; }
        public int CurrentMileage { get; set; }
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
        public virtual  ICollection<Form> Forms { get; set; }

    }
}
