using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackerTwo.Data;
using TrackerTwo.Models;


namespace TrackerTwo.Services
{
    public class LicenceService : ILicenceItemService
    {
        private readonly ApplicationDbContext _context;

        public LicenceService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LicenceItem>> getLicencesAsync()
        {
            return await _context.LicenceItems.ToListAsync();
        }

    }
}
