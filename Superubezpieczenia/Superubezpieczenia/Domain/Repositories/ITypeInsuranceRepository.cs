using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Repositories
{
    public interface ITypeInsuranceRepository
    {
        Task<IEnumerable<TypeInsurance>> AllTypeInsurance();
        TypeInsurance FindById(int id);
        void AddTypeInsurance(TypeInsurance TypeInsurance);
        void DeleteTypeInsurance(TypeInsurance TypeInsurance);
        void UpdateTypeInsurance(TypeInsurance TypeInsurance);
        bool SaveChanges();
    }
}
