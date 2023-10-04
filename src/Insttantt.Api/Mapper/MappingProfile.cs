using AutoMapper;
using Insttantt.Api.Models;
using Insttantt.Data.Entities;

namespace Insttantt.Api.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Flow, FlowModel>();
            CreateMap<Step, StepModel>();
            CreateMap<Field, FieldModel>();
        } 
    }
}
