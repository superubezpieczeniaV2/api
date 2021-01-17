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
    public class TypeOwnerController : ControllerBase
    {
        public readonly ITypeOwnerService _ownerService;
        public readonly IMapper _mapper;
        public readonly ILogService _log;
        public TypeOwnerController(ITypeOwnerService ownerService, IMapper mapper, ILogService log)
        {
            _ownerService = ownerService;
            _mapper = mapper;
            _log = log;

        }
        [HttpGet]
        public async Task<IEnumerable<TypeOwner>> AllTypeOwner()
        {
            var owner = await _ownerService.AllTypeOwner();

            return owner;
        }
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult<TypeOwnerVM> AddTypeOwner([FromBody] TypeOwnerDTO typeOwnerDTO)
        {
            var owner = _mapper.Map<TypeOwner>(typeOwnerDTO);
            _ownerService.AddTypeOwner(owner);
            _ownerService.SaveChanges();
            _log.Save(User?.Identity.Name, "Dodano rodzaj właściciela", GetType().Name);
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult DeleteTypeOwner(int id)
        {
            var owner = _ownerService.FindById(id);
            if (owner == null)
            {
                return NotFound();
            }

            _ownerService.DeleteTypeOwner(owner);
            _ownerService.SaveChanges();
            _log.Save(User?.Identity.Name, "Usunięto rodzaj właściciela", GetType().Name);
            return Ok();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult UpdateTypeOwner([FromBody] TypeOwnerDTO typeOwnerDTO, int id)
        {
            var owner = _ownerService.FindById(id);
            if (owner == null)
            {
                return NotFound();
            }
            _mapper.Map(typeOwnerDTO, owner);
            _ownerService.UpdateTypeOwner(owner);
            _ownerService.SaveChanges();
            _log.Save(User?.Identity.Name, "Edytowano rodzaj właściciela", GetType().Name);
            return Ok();
        }
      
    }
} 
