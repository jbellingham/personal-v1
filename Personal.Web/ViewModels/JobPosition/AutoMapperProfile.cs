using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Personal.ViewModels.JobPosition
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Domain.Models.JobPosition, JobPositionViewModel.Position>()
                .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToShortDateString()))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom<EndDateMapper>());
        }
    }

    public class EndDateMapper : IValueResolver<Domain.Models.JobPosition, JobPositionViewModel.Position, string>
    {
        public string Resolve(
            Domain.Models.JobPosition source,
            JobPositionViewModel.Position destination,
            string destMember,
            ResolutionContext context)
        {
            return source.EndDate?.ToShortDateString();
        }
    }
}