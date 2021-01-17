using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superubezpieczenia.Authentication;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Logger;
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
        public readonly ILogService _log;

        public ModelController(IModelService modelService, IMapper mapper, ILogService log)
        {
            _modelService = modelService;
            _mapper = mapper;
            _log = log;
        }
        [HttpGet]
        public async Task<IEnumerable<Model>> AllModels()
        {
            var model = await _modelService.AllModels();
            return model;
        }
        [HttpGet("{id}")]
        public async Task<IEnumerable<Model>> FindByMark(int id)
        {
            var model = await _modelService.FindByMark(id);
            return model;
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult<ModelVM> AddModel([FromBody] ModelDTO modelDTO)
        {
            var model = _mapper.Map<Model>(modelDTO);
            _modelService.AddModel(model);
            _modelService.SaveChanges();
            _log.Save(User.Identity.Name, "Dodano model", GetType().Name);

            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult DeleteModel(int id)
        {
            var dModel = _modelService.FindById(id);
            if (dModel==null)
            {
                return NotFound();
            }
            _modelService.DeleteModel(dModel);
            _modelService.SaveChanges();
            _log.Save(User.Identity.Name, "Usunięto model", GetType().Name);
            return Ok();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult UpdateModel([FromBody] ModelDTO modelDTO, int id)
        {
            var uMark = _modelService.FindById(id);
            if (uMark == null)
            {
                return NotFound();
            }
            _mapper.Map(modelDTO, uMark);
            _modelService.UpdateModel(uMark);
            _modelService.SaveChanges();
            _log.Save(User.Identity.Name, "Edytowano model", GetType().Name);

            return Ok();
        }

    }
}

