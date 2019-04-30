using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TrackerTwo.IntegrationTests
{
    public class LicenceRouting : IClassFixture<TestFixture>
    {
        private readonly HttpClient _client;

        public LicenceRouting(TestFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task LicenceControllerIndex_AnonymousGet_RedirectChallenge()
        {
            //arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/Licence");

            //act
            var response = await _client.SendAsync(request);

            //assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);

            Assert.Equal("http://localhost:8888/Identity/Account/Login?ReturnUrl=%2FLicence",response.Headers.Location.ToString());

        }

    }
}
