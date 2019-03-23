using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal.Domain;
using Personal.ViewModels;
using Personal.ViewModels.JobPosition;

namespace Personal.Controllers
{
    public class WorkExperienceController : BaseController
    {

        private readonly IMapper _mapper;

        public WorkExperienceController(DataContext dataContext, IMapper mapper) : base(dataContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IActionResult> Index()
        {
            var positions = await this.DataContext.JobPositions
                .Select(_ => _mapper.Map<JobPositionViewModel.Position>(_))
                .ToListAsync();
            
            var model = new JobPositionViewModel
            {
                Positions = positions
            };
            return Ok(model);
        }
    }
}