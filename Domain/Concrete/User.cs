using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Concrete
{
    public class User:IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        //public string Email { get; set; }

        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
