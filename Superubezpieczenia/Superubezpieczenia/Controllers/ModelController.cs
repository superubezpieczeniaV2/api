using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Resources.DTO;
using Superubezpieczenia.Resources.ViewModels;

namespace Superubezpieczenia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        public readonly IModelService _modelService;
        public readonly IMapper _mapper;

        public ModelController(IModelService modelService, IMapper mapper)
        {
            _modelService = modelService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Model>> AllModels()
        {
            var model = await _modelService.AllModels();
            return model;
        }
        [HttpPost]
        public ActionResult<ModelVM> AddModel(ModelDTO modelDTO)
        {
            var model = _mapper.Map<Model>(modelDTO);
            _modelService.AddModel(model);
            _modelService.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteModel(int id)
        {
            var dModel = _modelService.FindById(id);
            if (dModel==null)
            {
                return NotFound();
            }
            _modelService.DeleteModel(dModel);
            _modelService.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateModel(ModelDTO modelDTO, int id)
        {
            var uMark = _modelService.FindById(id);
            if (uMark == null)
            {
                return NotFound();
            }
            _mapper.Map(modelDTO, uMark);
            _modelService.UpdateModel(uMark);
            _modelService.SaveChanges();

            return Ok();
        }

    }
}

