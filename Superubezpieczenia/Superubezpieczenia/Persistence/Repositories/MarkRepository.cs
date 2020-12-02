using Microsoft.EntityFrameworkCore;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Persistence.Repositories
{
    public class MarkRepository : BaseRepository, IMarkRepository
    {
        public MarkRepository(ApplicationDbContext context) : base(context)
        {

        }
        public void AddMark(Mark mark)
        {
            _context.Marks.Add(mark);
        }

        public async Task<IEnumerable<Mark>> AllMarks()
        {
            return await _context.Marks.ToListAsync();
        }

        public void DeleteMark(Mark mark)
        {
            _context.Marks.Remove(mark);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateMark(Mark mark)
        {
        }
    };    
}
