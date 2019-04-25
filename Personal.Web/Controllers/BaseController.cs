using System;
using Microsoft.AspNetCore.Mvc;
using Personal.Domain;

namespace Personal.Controllers
{
    public class BaseController : Controller
    {
        protected readonly DataContext DataContext;

        public BaseController(DataContext dataContext)
        {
            this.DataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }
    }
}