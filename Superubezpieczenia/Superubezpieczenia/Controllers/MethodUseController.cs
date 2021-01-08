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
    public class MethodUseController : ControllerBase
    {
        public readonly IMethodUseService _methodUseService;
        public readonly IMapper _mapper;
        public readonly ILogService _log;
        public MethodUseController(IMethodUseService methodUseService, IMapper mapper, ILogService log)
        {
            _methodUseService = methodUseService;
            _mapper = mapper;
            _log = log;
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
            _log.Save(User.Identity.Name, "Dodano sposób użytkowania", GetType().Name);
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
            _log.Save(User.Identity.Name, "Usunięto sposób użytkowania", GetType().Name);
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
            _log.Save(User.Identity.Name, "Edytowano sposób użytkowania", GetType().Name);
            return Ok();
        }
    }
}