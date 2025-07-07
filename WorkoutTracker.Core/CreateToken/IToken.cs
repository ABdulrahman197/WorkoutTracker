using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTracker.Core.Entites;

namespace WorkoutTracker.Core.CreateToken
{
    public interface IToken
    {
        public Task<string> CreateTokenAsync(ApplicationUser _user, UserManager<ApplicationUser> _userManger);
    }
}
