using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackerTwo.Models;

namespace TrackerTwo.Services
{
   public interface ILicenceItemService
    {
        Task<IEnumerable<LicenceItem>> getLicencesAsync(string user);

        Task<bool> addLicenceItemAsync(LicenceItem licenceItem, string user);

        Task<bool> disableLicenceItemAsync(Guid id, string user);

        Task<LicenceItem> FindLicenceAsync(string User);
    }
}
