using System;
using Microsoft.AspNetCore.Mvc;
using Personal.Domain;

namespace Personal.Controllers
{
//    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected readonly DataContext DataContext;

        public BaseController(DataContext dataContext)
        {
            this.DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }
    }
}