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
using Superubezpieczenia.Resources.DTO;
using Superubezpieczenia.Resources.ViewModels;

namespace Superubezpieczenia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MethodUseController : ControllerBase
    {
        public readonly IMethodUseService _methodUseService;
        public readonly IMapper _mapper;
        public MethodUseController(IMethodUseService methodUseService, IMapper mapper)
        {
            _methodUseService = methodUseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MethodUse>> AllMethodUse()
        {
            var methodUse = await _methodUseService.AllMethodUse();
            return methodUse;

        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult<MethodUseVM> AddMethodUse(MethodUseDTO methodUseDTO)
        {
            var model = _mapper.Map<MethodUse>(methodUseDTO);
            _methodUseService.AddMethodUse(model);
            _methodUseService.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult DeleteMethodUse(int id)
        {
            var dMethodUse = _methodUseService.FindById(id);
            if (dMethodUse == null)
            {
                return NotFound();
            }
            _methodUseService.DeleteMethodUse(dMethodUse);
            _methodUseService.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult UpdateMethodUse(MethodUseDTO methodUseDTO, int id)
        {
            var uMark = _methodUseService.FindById(id);
            if (uMark == null)
            {
                return NotFound();
            }
            _mapper.Map(methodUseDTO, uMark);
            _methodUseService.UpdateMethodUse(uMark);
            _methodUseService.SaveChanges();

            return Ok();
        }
    }
}