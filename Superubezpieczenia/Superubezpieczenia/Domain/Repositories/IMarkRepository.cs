using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Repositories
{
    public interface IMarkRepository
    {
        Task<IEnumerable<Mark>> AllMarks();
        void AddMark(Mark mark);
        void DeleteMark(Mark mark);
        void UpdateMark(Mark mark);
        bool SaveChanges();
    }
}
