using Common.DTOs;
using Core.Services.Abstract;
using Domain.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News_Demo.Controllers
{
    public class UserController : Controller
    {
       

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly SignInManager<User> _signInManager;


        public UserController(ILogger<UserController> logger, IUserService userService, SignInManager<User> signInManager)
        {
            _logger = logger;
            _userService = userService;
            _signInManager = signInManager;

        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(UserDto userDto)
        {
            Task<IdentityResult> errors = _userService.CreateUser(userDto);
            if (await errors == null)
            {
                return View();
            }
            else
            {
                foreach (var error in errors.Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(userDto);
                }
            }

            return View();
        }

        public async Task<IActionResult> SignIn(UserDto userdto)
        {


            var identityResultsuccess = _userService.SignIn(userdto);
            if (await identityResultsuccess)//sucess result ı await yapmazsan async olmaz
            {
                return RedirectToAction("Index", "News");
            }

            ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
            return View();


        }
        //public async Task<IActionResult> LogOut()
        //{


        //    await _signInManager.SignOutAsync();//async metotları kullanabilmek için await keyword
        //    return RedirectToAction("Register", "Account");


        //}
    }
}

    