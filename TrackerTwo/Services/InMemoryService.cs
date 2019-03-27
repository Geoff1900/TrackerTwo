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
                Key = "123",
                ExpiresOn = DateTimeOffset.Now.AddDays(50)
            };

            var item2 = new LicenceItem()
            {
                Id = Guid.NewGuid(),
                User = "Alice",
                Key = "abc",
                ExpiresOn = DateTimeOffset.Now.AddDays(60)
};

            IEnumerable<LicenceItem> list = new List<LicenceItem>() { item1, item2 };

            return Task.FromResult(list);



        }
    }
}
