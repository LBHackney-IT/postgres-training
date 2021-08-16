using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PostgresTraining.V1.Boundary.Request;
using PostgresTraining.V1.Boundary.Response;
using PostgresTraining.V1.Controllers;
using PostgresTraining.V1.Domain;
using PostgresTraining.V1.Factories;
using PostgresTraining.V1.UseCase.Interfaces;
using System;
using Xunit;

namespace PostgresTraining.Tests.V1.Controllers
{
    public class PostgresTrainingControllerTests
    {
        private PostgresTrainingController _classUnderTest;
        private Mock<IGetByIdUseCase> _mockGetEntityByIdUseCase;
        private Mock<IPostPersonUseCase> _mockPostPersonUseCase;
        private Mock<IUpdatePersonUseCase> _mockUpdatePersonUseCase;

        public PostgresTrainingControllerTests()
        {
            _mockGetEntityByIdUseCase = new Mock<IGetByIdUseCase>();
            _mockPostPersonUseCase = new Mock<IPostPersonUseCase>();
            _mockUpdatePersonUseCase = new Mock<IUpdatePersonUseCase>();
            _classUnderTest = new PostgresTrainingController(_mockGetEntityByIdUseCase.Object, _mockPostPersonUseCase.Object, _mockUpdatePersonUseCase.Object);
        }

        [Fact]
        public void ViewRecordTest()
        {
            var person = new ResponseObject()
            {
                Id = 1234,
                DateOfBirth = new DateTime(),
                FirstName = "Test",
                MiddleName = "testing",
                Surname = "tester",
                PlaceOfBirth = "Toronto",
                Title = Title.Miss
            };

            _mockGetEntityByIdUseCase.Setup(x => x.Execute(person.Id)).Returns(person);
            var response = _classUnderTest.ViewRecord(person.Id) as OkObjectResult;

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
            response.Value.Should().Be(person);
        }

        [Fact]
        public void CreatePersonTest()
        {
            var useCaseResponse = new ResponseObject();
            _mockPostPersonUseCase.Setup(x => x.Execute(It.IsAny<PersonRequestObject>())).Returns(useCaseResponse);
            var result = _classUnderTest.CreatePersonRecord(It.IsAny<PersonRequestObject>()) as CreatedAtActionResult;

            result.Should().NotBeNull();
            result.Value.Should().BeEquivalentTo(useCaseResponse);
            result.StatusCode.Should().Be(201);
        }

        [Fact]
        public void UpdatePersonTest()
        {
            var useCaseResponse = new ResponseObject();
            _mockUpdatePersonUseCase.Setup(x => x.Execute(It.IsAny<PersonRequestObject>())).Returns(useCaseResponse);
            var result = _classUnderTest.UpdatePersonRecord(It.IsAny<PersonRequestObject>()) as NoContentResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(204);
        }



    }
}
