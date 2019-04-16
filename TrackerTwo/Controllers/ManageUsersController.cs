using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackerTwo.Models;

namespace TrackerTwo.Controllers
{
    [Authorize(Roles = Constants.AdministratorRole)]

    public class ManageUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ManageUsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var administrators = (await _userManager.GetUsersInRoleAsync(Constants.AdministratorRole)).ToList();
            var everyone = await _userManager.Users.ToListAsync();

            var model = new UsersViewModel() { Administrators = administrators, Everyone = everyone };
            return View(model);
        }
    }
}