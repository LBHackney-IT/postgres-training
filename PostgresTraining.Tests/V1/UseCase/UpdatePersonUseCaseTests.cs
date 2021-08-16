using AutoFixture;
using Moq;
using PostgresTraining.Tests.V1.Helper;
using PostgresTraining.V1.Boundary.Request;
using PostgresTraining.V1.Domain;
using PostgresTraining.V1.Factories;
using PostgresTraining.V1.Gateways;
using PostgresTraining.V1.Infrastructure;
using PostgresTraining.V1.UseCase;
using PostgresTraining.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PostgresTraining.Tests.V1.UseCase
{
    public class UpdatePersonUseCaseTests
    {
        private Mock<IExampleGateway> _mockGateway;
        private IUpdatePersonUseCase _classUnderTest;
        private readonly Fixture _fixture = new Fixture();

        public UpdatePersonUseCaseTests()
        {
            _mockGateway = new Mock<IExampleGateway>();
            _classUnderTest = new UpdatePersonUseCase(_mockGateway.Object);
        }

        [Fact]
        public void UseCaseShouldCallGateway()
        {
            var request = _fixture.Create<PersonRequestObject>();
            var expectedDomain = new Person
            {
                DateOfBirth = request.DateOfBirth,
                FirstName = request.FirstName,
                Id = request.Id,
                MiddleName = request.MiddleName,
                PlaceOfBirth = request.PlaceOfBirth,
                Surname = request.Surname,
                Title = request.Title
            };

            expectedDomain.FirstName = "Testing";

            _mockGateway.Setup(x => x.UpdatePerson(It.IsAny<Person>())).Returns(expectedDomain);
            _classUnderTest.Execute(request);
            _mockGateway.Verify();
        }
    }
}
