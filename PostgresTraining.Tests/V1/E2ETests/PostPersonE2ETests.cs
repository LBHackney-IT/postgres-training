using AutoFixture;
using FluentAssertions;
using Newtonsoft.Json;
using PostgresTraining.V1.Boundary.Request;
using PostgresTraining.V1.Domain;
using PostgresTraining.V1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PostgresTraining.Tests.V1.E2ETests
{
    [Collection("Integration collection")]

    public class PostPersonE2ETests : IntegrationTests<Startup>
    {
        private IFixture _fixture;

        public PostPersonE2ETests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public async Task PostPersonReturnCorrectResponse()
        {
            var expectedResponse = _fixture.Build<PersonRequestObject>()
                                            .Create();

            var uri = new Uri($"api/v1/residents", UriKind.Relative);
            var content = new StringContent(JsonConvert.SerializeObject(expectedResponse), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(uri, content).ConfigureAwait(false);
            response.StatusCode.Should().Be(201);

            var stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var convertedResponse = JsonConvert.DeserializeObject<PersonEntity>(stringContent);

            convertedResponse.Should().BeEquivalentTo(expectedResponse);

        }

        [Fact]
        public async Task PostPersonReturnsBadRequestAsync()
        {
            var uri = new Uri($"api/v1/residents", UriKind.Relative);
            var content = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(uri, content).ConfigureAwait(false);
            response.StatusCode.Should().Be(400);
        }


    }
}

