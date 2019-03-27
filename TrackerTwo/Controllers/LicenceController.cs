﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrackerTwo.Models;
using TrackerTwo.Services;

namespace TrackerTwo.Controllers
{
    public class LicenceController : Controller
    {
        private readonly ILicenceItemService _licenceService;
        public LicenceController(ILicenceItemService licenceService)
        {
            _licenceService = licenceService;
        }
        public async Task<IActionResult> Index()
        {
            return View(new LicenceViewModel() { Items = await _licenceService.getLicencesAsync() });
        }
    }
}