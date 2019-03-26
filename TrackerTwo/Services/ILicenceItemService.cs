using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackerTwo.Models;

namespace TrackerTwo.Services
{
   public interface ILicenceItemService
    {
        Task<IEnumerable<LicenceItem>> getLicencesAsync();
    }
}
