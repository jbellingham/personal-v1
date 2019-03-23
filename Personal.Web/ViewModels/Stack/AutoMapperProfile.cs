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
            this.CreateMap<ICollection<PositionTechnology>, StackViewModel>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom<StackItemResolver>());
        }
    }

    public class StackItemResolver : IValueResolver<ICollection<PositionTechnology>, StackViewModel, List<Technology>>
    {
        public List<Technology> Resolve(ICollection<PositionTechnology> source, StackViewModel destination, List<Technology> destMember, ResolutionContext context)
        {
            return source.Select(_ => new Technology
            {
                Name = _.Technology.Name
            }).ToList();
        }
    }
}