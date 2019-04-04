using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackerTwo.Models
{
    public class UsersViewModel
    {
        public IEnumerable<IdentityUser> Administrators { get; set; }
        public IEnumerable<IdentityUser> Everyone { get; set; }

    }
}
