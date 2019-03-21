using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personal.Domain;
using Personal.ViewModels;

namespace Personal.Controllers
{
    public class WorkExperienceController : BaseController
    {
        public WorkExperienceController(DataContext dataContext) : base(dataContext) { }

        public async Task<IActionResult> Index()
        {
            var model = await this.DataContext.JobPositions.Select(
                _ => new JobPositionViewModel
                {
                    Title = _.Title
                }).ToListAsync();

            return Ok(model);
        }
    }
}