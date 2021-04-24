using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntiCheat.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService

        public IActionResult Index()
        {
            return View();
        }
    }
}
