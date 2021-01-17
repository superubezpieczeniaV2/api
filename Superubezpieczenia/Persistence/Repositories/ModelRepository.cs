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
    public class ModelRepository : BaseRepository, IModelRepository
    {
        public ModelRepository(ApplicationDbContext context):base (context)
        {

        }
        public void AddModel(Model model)
        {
            _context.Models.Add(model);
        }

        public async Task<IEnumerable<Model>> AllModels()
        {
            return await _context.Models.Include(b => b.Mark).ToListAsync();
        }

        public void DeleteModel(Model model)
        {
            _context.Models.Remove(model);
        }

        public async Task<IEnumerable<Model>> FindByMark(int id)
        {
             
            return await _context.Models.Include(b => b.Mark).Where(x => x.IDMark == id).ToListAsync();
        }
        public Model FindById(int id)
        {
           return _context.Models.FirstOrDefault(p => p.IDModel == id);
           
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public Model SelectedModel(string name)
        {
            return _context.Models.FirstOrDefault(p => p.Name == name);
        }

        public void UpdateModel(Model model)
        {
            
        }
    }
}
