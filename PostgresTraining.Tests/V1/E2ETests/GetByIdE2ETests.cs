using AutoFixture;
using FluentAssertions;
using Newtonsoft.Json;
using PostgresTraining.V1.Infrastructure;
using System;
using System.Threading.Tasks;
using Xunit;

namespace PostgresTraining.Tests.V1.E2ETests
{
    [Collection("Integration collection")]
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
            int id = 1234;
            var expectedResponse = E2ETestHelpers.AddPersonToDb(DatabaseContext, id);

            var uri = new Uri($"api/v1/residents/{id}", UriKind.Relative);
            var response = await _client.GetAsync(uri).ConfigureAwait(false);
            response.StatusCode.Should().Be(200);

            var stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var convertedResponse = JsonConvert.DeserializeObject<PersonEntity>(stringContent);

            convertedResponse.Should().BeEquivalentTo(expectedResponse);

        }

        [Fact]
        public async Task GetResidentByIdReturns404IfNotFoundAsync()
        {
            var uri = new Uri($"api/v1/residents/123467", UriKind.Relative);
            var response = await _client.GetAsync(uri).ConfigureAwait(false);
            response.StatusCode.Should().Be(404);
        }


    }
}
