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
        public async Task addLicenceItem_ValidLicenceItem_ReturnsTrue()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestAddLicenceItem").Options;
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

        [Fact]
        public async Task disableLicenceItem_ValidLicenceID_ReturnsTrue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "TestDisableLicenceItem").Options;
            using (var context = new ApplicationDbContext(options))
            {
                var service = new LicenceService(context);
                string User = "Sandra?";
                await service.addLicenceItemAsync(new LicenceItem
                {
                    User = User,
                    Key = "qwerty?",
                    IsDisabled = false
                });
                var licenceItem = await service.FindLicenceAsync(User);
                Assert.True(await service.disableLicenceItemAsync(licenceItem.Id));
            }
        }
    }
}