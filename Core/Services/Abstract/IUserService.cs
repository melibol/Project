using Common.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Abstract
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUser(UserDto user);

        Task<bool> SignIn(UserDto user);

        
    }
}
