using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrackerTwo.Models;
using TrackerTwo.Services;

namespace TrackerTwo.Controllers
{
    [Authorize]
    public class LicenceController : Controller
    {
        private readonly ILicenceItemService _licenceService;
        private readonly UserManager<IdentityUser> _userManager;
        public LicenceController(ILicenceItemService licenceService, UserManager<IdentityUser> userManager)
        {
            _licenceService = licenceService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            //var x = User;
            
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();
            return View(new LicenceViewModel() { Items = await _licenceService.getLicencesAsync(currentUser.UserName) });
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLicenceItem(LicenceItem licenceItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var success = await _licenceService.addLicenceItemAsync(licenceItem, currentUser.UserName);

            if (!success)
            {
                return BadRequest("Item could not be added!");
            }
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DisableLicence(Guid Id)
        {
            if( Id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            if (!await _licenceService.disableLicenceItemAsync(Id, currentUser.UserName))
            {
                return BadRequest("Could not disable licence");
            }

            return RedirectToAction("Index");

        }

    }
}