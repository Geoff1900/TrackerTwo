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
        public async Task<IEnumerable<LicenceItem>> getLicencesAsync(string user)
        {
            return await _context.LicenceItems.Where(x=>x.AdminUser == user).ToListAsync();
        }

        public  async Task<bool> addLicenceItemAsync(LicenceItem licenceItem, string user)
        {
            licenceItem.Id = Guid.NewGuid();
            licenceItem.ExpiresOn = DateTimeOffset.Now.AddDays(365);
            licenceItem.AdminUser = user;
           _context.LicenceItems.Add(licenceItem);
            return await _context.SaveChangesAsync() ==1;
        }

        public async Task<bool> disableLicenceItemAsync(Guid id, string user)
        {
            var licenceItem = await _context.LicenceItems.Where(x => x.Id== id && x.AdminUser ==user).SingleOrDefaultAsync();

            if (licenceItem == null) return false;

            licenceItem.IsDisabled = true;
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<LicenceItem> FindLicenceAsync(string user)
        {
            return await _context.LicenceItems.Where(x => x.User == user).SingleOrDefaultAsync();
        }
    }
} 
