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
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate.ToShortDateString()))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom<EndDateMapper>())
                .ForMember(dest => dest.Stack, opt => opt.MapFrom<TechStackMapper>());
        }
    }

    public class TechStackMapper : IValueResolver<Domain.Models.JobPosition, JobPositionViewModel.Position, List<JobPositionViewModel.Technology>>
    {
        public List<JobPositionViewModel.Technology> Resolve(Domain.Models.JobPosition source, JobPositionViewModel.Position destination, List<JobPositionViewModel.Technology> destMember, ResolutionContext context)
        {
            return source.Stack
                .OrderBy(_ => _.Technology.Ordinal)
                .Select(_ => new JobPositionViewModel.Technology
                {
                    Name = _.Technology.Name
                }).ToList();
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