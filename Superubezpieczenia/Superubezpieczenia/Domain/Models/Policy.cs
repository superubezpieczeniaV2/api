using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class Policy
    {
        [Key]
        public int IDPolicy { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IDForm { get; set; }
        public int IDPriceList { get; set; }
        [ForeignKey("IDForm")]
        public virtual Form Form { get; set; }
        [ForeignKey("IDPriceList")]
        public virtual PriceList PriceList { get; set; }
    }
}
