using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal.Domain;
using Personal.ViewModels.Stack;

namespace Personal.Controllers
{
    public class StackController : BaseController
    {
        private readonly IMapper _mapper;
        public StackController(DataContext dataContext, IMapper mapper) : base(dataContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IActionResult> Index(Guid positionId)
        {
            var position = await this.DataContext.JobPositions
                .Include(_ => _.Stack)
                    .ThenInclude(_ => _.Technology)
                .SingleOrDefaultAsync(_ => _.Id == positionId);

            var model = _mapper.Map<StackViewModel>(position.Stack);
            return Ok(model);
        }
    }
}