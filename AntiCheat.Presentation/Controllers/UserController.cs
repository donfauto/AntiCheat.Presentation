using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntiCheat.BusinessLogic.Services.Contracts;
using AntiCheat.BusinessLogic.Models;
using AntiCheat.DataAccess.Models;

namespace AntiCheat.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //Mostrar lista de usuarios
        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                return View(users);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
           
        }

        //Guardar usuario
        public IActionResult SaveUser()
        {
            ViewBag.Success = TempData["Success"];
            ViewBag.Danger = TempData["Danger"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveUser(User user)
        {
            try
            {
                if (user == null)
                {
                    return View();
                }
                else
                {
                    var saveUser = await _userService.SaveUserAsync(user);
                    TempData["Success"] = "Usuario agregado.";
                    
                }
                return RedirectToAction("SaveUser");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }
    }
}
