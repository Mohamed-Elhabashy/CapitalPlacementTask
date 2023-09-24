using AutoMapper;
using Capital_Placement_Task.DTO;
using Capital_Placement_Task.Models;
using Capital_Placement_Task.Repositroy.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Capital_Placement_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramDetialsController : ControllerBase
    {
        private readonly IBaseRepository<ProgramApplication> _context;
        private readonly IMapper _mapper;
        public ProgramDetialsController(IBaseRepository<ProgramApplication> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Program
        [HttpGet]
        public ActionResult<IEnumerable<ProgramDto>> GetProgramApplications()
        {
            var ProgramApplications = _context.GetAll();
            var programDtos = _mapper.Map<IEnumerable<ProgramDto>>(ProgramApplications);

            return programDtos.ToList(); // You may need to convert the result to a list, depending on your action return type

        }

        // GET: api/Program/5
        [HttpGet("{id}")]
        public ActionResult<ProgramDto> GetProgram(int id)
        {
            var program = _context.GetById(id);

            if (program == null)
            {
                return NotFound();
            }
            var programDto = _mapper.Map<ProgramDto>(program);
            return programDto;
        }

        // POST: api/Program
        [HttpPost]
        public ActionResult<ProgramDto> CreateProgram(ProgramDto programDto)
        {
            var program = _mapper.Map<ProgramApplication>(programDto);

            _context.Add(program);

            return CreatedAtAction(nameof(GetProgram), new { id = program.Id }, programDto);
        }

        // PUT: api/Program/5
        [HttpPut("{id}")]
        public IActionResult UpdateProgram(int id, ProgramDto programDto)
        {
            if (id != programDto.Id)
            {
                return BadRequest();
            }
            var program = _mapper.Map<ProgramApplication>(programDto);
            program = _context.Update(id,program);

            if (program == null)
            {
                return NotFound();
            }
            

            return NoContent();
        }

       
    }
}
