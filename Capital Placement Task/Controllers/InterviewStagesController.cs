using AutoMapper;
using Capital_Placement_Task.DTO;
using Capital_Placement_Task.Models;
using Capital_Placement_Task.Repositroy.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capital_Placement_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewStagesController : ControllerBase
    {
        private readonly IBaseRepository<InterviewStage> _context;
        private readonly IMapper _mapper;
        public InterviewStagesController(IBaseRepository<InterviewStage> context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<InterviewStageDTO>> GetInterviewStages()
        {
            var stages = _context.GetAll();
            var stageDTOs = _mapper.Map<List<InterviewStageDTO>>(stages);
            return stageDTOs;
        }

        [HttpGet("{id}")]
        public ActionResult<InterviewStageDTO> GetInterviewStage(int id)
        {
            var stage = _context.GetById(id);

            if (stage == null)
            {
                return NotFound();
            }

            var stageDTO = _mapper.Map<InterviewStageDTO>(stage);
            return stageDTO;
        }

        [HttpPut("{id}")]
        public IActionResult PutInterviewStage(int id, InterviewStageDTO stageDTO)
        {
            if (id != stageDTO.Id)
            {
                return BadRequest();
            }

            var stage = _mapper.Map<InterviewStage>(stageDTO);
            stage = _context.Update(id, stage);
            if (stage == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
