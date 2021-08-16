using PostgresTraining.V1.Gateways;
using PostgresTraining.V1.UseCase;
using Moq;
using Xunit;
using AutoFixture;
using PostgresTraining.V1.Domain;
using PostgresTraining.V1.Factories;
using FluentAssertions;

namespace PostgresTraining.Tests.V1.UseCase
{
    public class GetByIdUseCaseTests
    {
        private Mock<IExampleGateway> _mockGateway;
        private GetByIdUseCase _classUnderTest;
        private readonly Fixture _fixture = new Fixture();


        public GetByIdUseCaseTests()
        {
            _mockGateway = new Mock<IExampleGateway>();
            _classUnderTest = new GetByIdUseCase(_mockGateway.Object);
        }

        [Fact]
        public void ReturnResponse()
        {
            var stubbedResponse = _fixture.Create<Person>();
            _mockGateway.Setup(x => x.GetEntityById(1234)).Returns(stubbedResponse);

            var response = _classUnderTest.Execute(1234);
            var expectedResponse = stubbedResponse.ToResponse();

            response.Should().NotBeNull();
            response.Should().BeEquivalentTo(expectedResponse);

        }
    }
}
