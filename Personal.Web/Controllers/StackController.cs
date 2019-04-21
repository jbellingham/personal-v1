using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal.Domain;
using Personal.Domain.Models;
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

        public async Task<IActionResult> Index()
        {
            var positions = await this.DataContext.JobPositions
                .Include(_ => _.Stack)
                .ThenInclude(_ => _.Technology)
                .ToListAsync();

            var model = _mapper.Map<StackViewModel.Display>(positions);
            return Ok(model);
        }
    
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Index([FromBody] StackViewModel.Add model)
        {
            if (ModelState.IsValid)
            {
                var position = await this.DataContext.JobPositions
                    .Include(_ => _.Stack)
                    .SingleOrDefaultAsync(_ => _.Id == model.PositionId);
    
                var technology = await this.DataContext.Technologies.FirstOrDefaultAsync(_ => _.Name == model.Value);
                
                position.Stack.Add(new PositionTechnology
                {
                    Technology = technology ??
                                 new Domain.Models.Technology
                                {
                                    Name = model.Value
                                }
                });
                
                await this.DataContext.SaveChangesAsync();
            }
            return Ok();
        }
    }
}