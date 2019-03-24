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
            this.CreateMap<ICollection<Domain.Models.JobPosition>, StackViewModel>()
                .ForMember(dest => dest.Positions, opt => opt.MapFrom<PositionsResolver>());
        }
    }

    public class PositionsResolver : IValueResolver<ICollection<Domain.Models.JobPosition>, StackViewModel, List<StackViewModel.Position>>
    {
        public List<StackViewModel.Position> Resolve(
            ICollection<Domain.Models.JobPosition> source,
            StackViewModel destination,
            List<StackViewModel.Position> destMember,
            ResolutionContext context)
        {
            return source.Select(_ => new StackViewModel.Position
            {
                PositionId = _.Id,
                Stack = _.Stack.Select(s => new Technology
                {
                    Name = s.Technology.Name
                }).ToList()
            }).ToList();
        }
    }
}