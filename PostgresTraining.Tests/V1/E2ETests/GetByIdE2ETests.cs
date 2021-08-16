using AutoFixture;
using FluentAssertions;
using Newtonsoft.Json;
using PostgresTraining.V1.Infrastructure;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PostgresTraining.Tests.V1.E2ETests
{
    [Collection("IntegrationTests")]
    public class GetByIdE2ETests : IntegrationTests<Startup>
    {
        private IFixture _fixture;

        public GetByIdE2ETests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetByIdReturnCorrectResponse()
        {
            var id = _fixture.Create<int>();
            var expectedResponse = E2ETestHelpers.AddPersonToDb(DatabaseContext, id);

            var uri = new Uri($"api/v1/residents/{id}", UriKind.Relative);
            var response = Client.GetAsync(uri);
            response.Result.StatusCode.Should().Be(200);

            var stringContent = await response.Result.Content.ReadAsStringAsync().ConfigureAwait(false);
            var convertedResponse = JsonConvert.DeserializeObject<PersonEntity>(stringContent);

            convertedResponse.Should().BeEquivalentTo(expectedResponse);

        }

        [Fact]
        public void GetResidentByIdReturns404IfNotFound()
        {
            var uri = new Uri($"api/v1/residents/1234", UriKind.Relative);
            var response = Client.GetAsync(uri);
            response.Result.StatusCode.Should().Be(404);
        }


    }
}
