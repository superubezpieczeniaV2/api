using Superubezpieczenia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Domain.Services
{
  public  interface IModelService
    {
        Task<IEnumerable<Model>> AllModels();
        Model SelectedModel(string name);
        Task<IEnumerable<Model>> FindByMark(int id);
        Model FindById(int id);
        void AddModel(Model model);
        void DeleteModel(Model model);
        void UpdateModel(Model model);

        bool SaveChanges();
    }
}
