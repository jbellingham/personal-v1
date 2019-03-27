using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Personal.Domain.Models;

namespace Personal.ViewModels.Stack
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<ICollection<Domain.Models.JobPosition>, StackViewModel.Display>()
                .ForMember(dest => dest.Positions, opt => opt.MapFrom<PositionsResolver>());
        }
    }

    public class PositionsResolver : IValueResolver<ICollection<Domain.Models.JobPosition>, StackViewModel.Display, List<StackViewModel.Position>>
    {
        public List<StackViewModel.Position> Resolve(
            ICollection<Domain.Models.JobPosition> source,
            StackViewModel.Display destination,
            List<StackViewModel.Position> destMember,
            ResolutionContext context)
        {
            return source.Select(_ => new StackViewModel.Position
            {
                PositionId = _.Id,
                Stack = _.Stack
                    .OrderBy(t => t.Technology.Ordinal)
                    .Select(s => new Technology
                    {
                        Name = s.Technology.Name
                    }).ToList()
            }).ToList();
        }
    }
}