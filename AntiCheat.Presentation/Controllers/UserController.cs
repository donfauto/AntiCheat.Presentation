using AntiCheat.BusinessLogic.Services.Contracts;
using AntiCheat.DataAccess.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AntiCheat.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Register()
        {
            ViewBag.Error = TempData["Error"];
            ViewBag.Success = TempData["Success"];
            ViewBag.send = TempData["send"];
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                if (user.Password != user.ConfirmPassword)
                {

                    TempData["Error"] = "Las Contraseñas no coinciden";
                }
                else
                {
                    await _userService.SaveUserAsync(user);
                    TempData["Success"] = "Registrado con Exito!";

                }
                return RedirectToAction("Register");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }

        }

        public IActionResult Login()
        {
            ViewBag.Wrong = TempData["Wrong"];

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            try
            {
                var userInDb = await _userService.LoginAsync(user.UserName, user.Password);

                if (userInDb != null)
                {
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.NameIdentifier);
                    identity.AddClaim(new Claim(ClaimTypes.Name, userInDb.UserName));
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userInDb.Id.ToString()));
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                    new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddHours(1), IsPersistent = true });
                    TempData["Loged"] = user.UserName + " Bienvenido";
                    return RedirectToAction("Index", "Ticket");
                }
                else
                {
                    TempData["Wrong"] = "Contraseña o usuario incorrectos";
                    return RedirectToAction("Login", "User");

                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();

            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/User/Login");

        }
    }
}