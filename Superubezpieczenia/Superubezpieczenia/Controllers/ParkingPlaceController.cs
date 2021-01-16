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
    public class ParkingPlaceController : ControllerBase
    {
        public readonly IParkingPlaceService _parkingPlaceService;
        public readonly IMapper _mapper;
        public readonly ILogService _log;
        public ParkingPlaceController(IParkingPlaceService parkingPlaceService, IMapper mapper, ILogService log)
        {
            _parkingPlaceService = parkingPlaceService;
            _mapper = mapper;
            _log = log;
        }
        [HttpGet]
        public async Task<IEnumerable<ParkingPlace>> AllParkingPlace()
        {
            var parkingPlace=await _parkingPlaceService.AllParkingPlace();
            return parkingPlace;
        }
       
        
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult<ParkingPlaceVM> AddParkingPlace([FromBody] ParkingPlaceDTO parkingPlaceDTO)
        {
            var parkingPlace = _mapper.Map<ParkingPlace>(parkingPlaceDTO);
            _parkingPlaceService.AddParkingPlace(parkingPlace);
            _parkingPlaceService.SaveChanges();
            _log.Save(User.Identity.Name, "Dodano rodzaj miejsca parkingowego ", GetType().Name);
            return Ok();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult DeleteParkingPlace(int id)
        {
            var parkingPlace = _parkingPlaceService.FindById(id);
            if (parkingPlace == null)
            {
                return NotFound();
            }
            _parkingPlaceService.DeleteParkingPlace(parkingPlace);
            _parkingPlaceService.SaveChanges();
            _log.Save(User.Identity.Name, "Usunięto rodzaj miejsca parkingowego ", GetType().Name);
            return Ok();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public ActionResult UpdateParkingPlace([FromBody] ParkingPlaceDTO parkingPlaceDTO, int id)
        {
            var uMark = _parkingPlaceService.FindById(id);
            if (uMark == null)
            {
                return NotFound();
            }
            _mapper.Map(parkingPlaceDTO, uMark);
            _parkingPlaceService.UpdateParkingPlace(uMark);
            _parkingPlaceService.SaveChanges();
            _log.Save(User.Identity.Name, "Edytowano rodzaj miejsca parkingowego ", GetType().Name);
            return Ok();
        }
    }
}
