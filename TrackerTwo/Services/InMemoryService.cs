using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackerTwo.Models;

namespace TrackerTwo.Services
{
    public class InMemoryService : ILicenceItemService
    {
        public async Task<bool> addLicenceItemAsync(LicenceItem licenceItem, string user)
        {
            return await Task.FromResult<bool>(true);
        }

        public async Task<bool> disableLicenceItemAsync(Guid id, string user)
        {
            throw new NotImplementedException();
        }

        public async Task<LicenceItem> FindLicenceAsync(string user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LicenceItem>> getLicencesAsync(string user)
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

            return await Task.FromResult(list);



        }
    }
}
