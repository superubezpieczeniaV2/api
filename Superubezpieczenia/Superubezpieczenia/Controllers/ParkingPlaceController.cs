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
    public class ParkingPlaceController : ControllerBase
    {
        public readonly IParkingPlaceService _parkingPlaceService;
        public readonly IMapper _mapper;
        public ParkingPlaceController(IParkingPlaceService parkingPlaceService, IMapper mapper)
        {
            _parkingPlaceService = parkingPlaceService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<ParkingPlace>> AllParkingPlace()
        {
            var parkingPlace=await _parkingPlaceService.AllParkingPlace();
            return parkingPlace;
        }
        [HttpPost]
        public ActionResult<ParkingPlaceVM> AddParkingPlace(ParkingPlaceDTO parkingPlaceDTO)
        {
            var parkingPlace = _mapper.Map<ParkingPlace>(parkingPlaceDTO);
            _parkingPlaceService.AddParkingPlace(parkingPlace);
            _parkingPlaceService.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteParkingPlace(int id)
        {
            var parkingPlace = _parkingPlaceService.FindById(id);
            if (parkingPlace == null)
            {
                return NotFound();
            }
            _parkingPlaceService.DeleteParkingPlace(parkingPlace);
            _parkingPlaceService.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateParkingPlace(ModelDTO modelDTO, int id)
        {
            var uMark = _parkingPlaceService.FindById(id);
            if (uMark == null)
            {
                return NotFound();
            }
            _mapper.Map(modelDTO, uMark);
            _parkingPlaceService.UpdateParkingPlace(uMark);
            _parkingPlaceService.SaveChanges();

            return Ok();
        }
    }
}
