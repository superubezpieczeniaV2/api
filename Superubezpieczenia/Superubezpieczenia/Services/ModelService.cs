using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Repositories;
using Superubezpieczenia.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Superubezpieczenia.Services
{
    public class ModelService : IModelService
    {
        public readonly IModelRepository _modelRepository;
        public ModelService(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }
        public void AddModel(Model model)
        {
            _modelRepository.AddModel(model);
        }

        public async Task<IEnumerable<Model>> AllModels()
        {
            return await _modelRepository.AllModels();
        }

        public void DeleteModel(Model model)
        {
            _modelRepository.DeleteModel(model);
        }
        public Model FindById(int id)
        {
            return _modelRepository.FindById(id);
        }

        public bool SaveChanges()
        {
            return _modelRepository.SaveChanges();
        }

        public Model SelectedModel(string name)
        {
            return _modelRepository.SelectedModel(name);
        }

        public void UpdateModel(Model model)
        {
            _modelRepository.UpdateModel(model);
        }
    }
}
