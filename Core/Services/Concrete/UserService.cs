using AutoMapper;
using Common.DTOs;
using Core.Services.Abstract;
using Domain.Concrete;
using Domain.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Concrete
{
    public class UserService : IUserService
    {
        //private readonly NewsContext _context = null;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private NewsContext context = null;

        public UserService(UserManager<User>usermanager,SignInManager<User>signInManager,IMapper mapper,NewsContext _newsContext)
        {
            _signInManager = signInManager;
            _userManager = usermanager;
            _mapper = mapper;
            this.context = _newsContext;            
        }
        public async Task<IdentityResult> CreateUser(UserDto dto)
        {
            User user = new User();
            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.UserName = dto.Email;
            user.Email = dto.Email;
            user.Password = dto.Password;
            user.CreatedDate = DateTime.Now;

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                return null;
            }

            return result;

            
        }

        public async Task<bool> SignIn(UserDto user)
        {
            var identityresult = await _signInManager.PasswordSignInAsync(user.Email, user.Password, true, false); //cookienin sürekli kalması için true
            var success = identityresult.Succeeded;

            return success;
        }
    }
}
