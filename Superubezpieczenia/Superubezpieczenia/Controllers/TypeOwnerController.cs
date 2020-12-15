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
    public class TypeOwnerController : ControllerBase
    {
        public readonly ITypeOwnerService _ownerService;
        public readonly IMapper _mapper;
        public TypeOwnerController(ITypeOwnerService ownerService, IMapper mapper)
        {
            _ownerService = ownerService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<TypeOwner>> AllTypeOwner()
        {
            var owner = await _ownerService.AllTypeOwner();

            return owner;
        }
        [HttpPost]
        public ActionResult<TypeOwnerVM> AddTypeOwner(TypeOwnerDTO typeOwnerDTO)
        {
            var owner = _mapper.Map<TypeOwner>(typeOwnerDTO);
            _ownerService.AddTypeOwner(owner);
            _ownerService.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteTypeOwner(int id)
        {
            var owner = _ownerService.FindById(id);
            if (owner == null)
            {
                return NotFound();
            }

            _ownerService.DeleteTypeOwner(owner);
            _ownerService.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateTypeOwner(TypeOwnerDTO typeOwnerDTO, int id)
        {
            var owner = _ownerService.FindById(id);
            if (owner == null)
            {
                return NotFound();
            }
            _mapper.Map(typeOwnerDTO, owner);
            _ownerService.UpdateTypeOwner(owner);
            _ownerService.SaveChanges();

            return Ok();
        }
      
    }
} 
