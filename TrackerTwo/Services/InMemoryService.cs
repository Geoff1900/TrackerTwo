using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackerTwo.Models;

namespace TrackerTwo.Services
{
    public class InMemoryService : ILicenceItemService
    {
        public Task<IEnumerable<LicenceItem>> getLicencesAsync()
        {
            var item1 = new LicenceItem()
            {
                Id = Guid.NewGuid(),
                User = "Geoff",
                Key = "123"

            };
            var item2 = new LicenceItem()
            {
                Id = Guid.NewGuid(),
                User = "Alice",
                Key = "abc"

            };

            IEnumerable<LicenceItem> list = new List<LicenceItem>() { item1, item2 };

            return Task.FromResult(list);



        }
    }
}
