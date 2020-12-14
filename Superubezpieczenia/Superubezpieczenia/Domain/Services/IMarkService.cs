using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Services
{
    public interface IMarkService
    {
        Task<IEnumerable<Mark>> AllMarks();
        Mark SelectedMark(string name);
        Mark FindById(int id);
        void AddMark(Mark mark);
        void DeleteMark(Mark mark);
        void UpdateMark(Mark mark);
        bool SaveChanges();
    }
}
