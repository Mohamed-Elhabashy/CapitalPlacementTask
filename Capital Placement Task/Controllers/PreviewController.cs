using AutoMapper;
using Capital_Placement_Task.DTO;
using Capital_Placement_Task.Models;
using Capital_Placement_Task.Repositroy.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capital_Placement_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewController : ControllerBase
    {
        private readonly IBaseRepository<ProgramApplication> _context;
        private readonly IMapper _mapper;
        public PreviewController(IBaseRepository<ProgramApplication> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
    }
}
