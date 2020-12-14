using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Superubezpieczenia.Domain.Models;
using Superubezpieczenia.Domain.Services;
using Superubezpieczenia.Resources.DTO;
using Superubezpieczenia.Resources.ViewModels;



namespace Superubezpieczenia.Controllers
{
    [Route("api/[controller]")]
    public class MarkController : Controller
    {
        public readonly IMarkService _markService;
        public readonly IMapper _mapper;

        public MarkController(IMarkService markService, IMapper mapper)
        {
            _markService = markService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Mark>> AllMarks()
        {
            var mark = await _markService.AllMarks();
            return mark;
        }
        [HttpPost]
        public ActionResult<MarkVM> AddMark(MarkDTO markDTO)
        {
            var mark = _mapper.Map<Mark>(markDTO);
            _markService.AddMark(mark);
            _markService.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteMark(int id)
        {
            var dMark = _markService.FindById(id);
            if (dMark == null)
            {
                return NotFound();
            }
            
            _markService.DeleteMark(dMark);
            _markService.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateMark(MarkDTO markDTO, int id)
        {
            var uMark = _markService.FindById( id);
            if (uMark == null)
            {
                return NotFound();
            }
            _mapper.Map(markDTO, uMark);
            _markService.UpdateMark(uMark);
            _markService.SaveChanges();

            return Ok();
        }
        /*[HttpGet("{name}")]
        public ActionResult SelectedMark(string name)
        {
            var sMark = _markService.SelectedMark(name);
            return Ok(_mapper.Map<MarkVM>(sMark));
        }*/
        
    }
}
