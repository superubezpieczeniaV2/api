using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Models
{
    public class PriceList
    {
        [Key]
        public int IDPriceList { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
    }
}
