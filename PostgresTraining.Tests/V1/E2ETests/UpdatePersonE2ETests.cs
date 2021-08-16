using AutoFixture;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PostgresTraining.Tests.V1.E2ETests
{
    [Collection("IntegrationTests")]
    public class UpdatePersonE2ETests : IntegrationTests<Startup>
    {
        private IFixture _fixture;

        public UpdatePersonE2ETests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void PostPersonReturnCorrectResponse()
        {
            var id = _fixture.Create<int>();
            var expectedResponse = E2ETestHelpers.AddPersonToDb(DatabaseContext, id);

            var uri = new Uri($"api/v1/residents/", UriKind.Relative);
            var content = new StringContent(JsonConvert.SerializeObject(expectedResponse), Encoding.UTF8, "application/json");

            var response = Client.PostAsync(uri, content);
            response.Result.StatusCode.Should().Be(204);

        }

        [Fact]
        public void PostPersonReturnsBadRequest()
        {
            var uri = new Uri($"api/v1/residents/", UriKind.Relative);
            var content = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json");
            var response = Client.PostAsync(uri, content);
            response.Result.StatusCode.Should().Be(404);
        }


    }
}
