using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrackerTwo.Data;
using TrackerTwo.Models;
using TrackerTwo.Services;
using Xunit;

namespace TrackerTwo.UnitTests
{
    public class LicenceServiceTest
    {

        [Fact]
        public async Task DisableLicenceItem_ValidLicenceItemID_ReturnsTrue()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "Test_DisableLicenceItem").Options;
            using (var context = new ApplicationDbContext(options))
            {
                var service = new LicenceService(context);
                //Act
                await service.addLicenceItemAsync(new LicenceItem
                {
                    User = "Sandra?",
                    Key = "qwerty?"
                });
            };

            //Assert
            using (var context = new ApplicationDbContext(options))
            {
                Assert.Equal(1, await context.LicenceItems.CountAsync());
            }
        }

      

    }
}
