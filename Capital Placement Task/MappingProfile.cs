using AutoMapper;
using Capital_Placement_Task.DTO;
using Capital_Placement_Task.Models;
namespace Capital_Placement_Task
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ProgramApplication, ProgramDto>();
            CreateMap<ProgramDto,ProgramApplication>();
            CreateMap<InterviewStageDTO, InterviewStage>();

            CreateMap<InterviewStage, InterviewStageDTO>();
        }
    }
}
