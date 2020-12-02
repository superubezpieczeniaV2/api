using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Services
{
    public class MarkService : IMarkService
    {
        public readonly IMarkRepository _markRepository;
        public MarkService(IMarkRepository markRepository)
        {
            _markRepository = markRepository;

        }

        public void AddMark(Mark mark)
        {
            _markRepository.AddMark(mark);
        }

        public async Task<IEnumerable<Mark>> AllMarks()
        {
            return await _markRepository.AllMarks();
        }

        public void DeleteMark(Mark mark)
        {
            _markRepository.DeleteMark(mark);
        }

        public bool SaveChanges()
        {
           return _markRepository.SaveChanges();
        }

        public void UpdateMark(Mark mark)
        {
            _markRepository.UpdateMark(mark);
        }
    }
}
