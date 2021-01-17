using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Services
{
    public interface ITypeInsuranceService
    {
        Task<IEnumerable<TypeInsurance>> AllTypeInsurance();
        TypeInsurance FindById(int id);
        void AddTypeInsurance(TypeInsurance typeInsurance);
        void DeleteTypeInsurance(TypeInsurance typeInsurance);
        void UpdateTypeInsurance(TypeInsurance typeInsurance);
        bool SaveChanges();
    }
}
