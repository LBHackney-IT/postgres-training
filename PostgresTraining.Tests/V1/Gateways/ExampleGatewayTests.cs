using AutoFixture;
using PostgresTraining.Tests.V1.Helper;
using PostgresTraining.V1.Domain;
using PostgresTraining.V1.Gateways;
using FluentAssertions;
using NUnit.Framework;
using PostgresTraining.V1.Factories;
using Xunit;
using PostgresTraining.V1.Infrastructure;
using PostgresTraining.V1.Boundary.Request;
using System;

namespace PostgresTraining.Tests.V1.Gateways
{
    [Collection("Postgres collection")]
    public class ExampleGatewayTests : DatabaseTests<Startup>
    {
        private readonly Fixture _fixture = new Fixture();
        private ExampleGateway _classUnderTest;

        public ExampleGatewayTests()
        {
            _classUnderTest = new ExampleGateway(DatabaseContext);
        }

        [Fact]
        public void GetEntityByIdReturnsNullIfEntityDoesntExist()
        {
            var response = _classUnderTest.GetEntityById(0);

            response.Should().BeNull();
        }

        [Fact]
        public void GetEntityByIdReturnsTheEntityIfItExists()
        {
            var entity = _fixture.Create<Person>();
            var databaseEntity = DatabaseEntityHelper.CreateDatabaseEntityFrom(entity.ToDatabase());

            DatabaseContext.Persons.Add(databaseEntity);
            DatabaseContext.SaveChanges();

            var response = _classUnderTest.GetEntityById(databaseEntity.Id);

            databaseEntity.Id.Should().Be(response.Id);
        }

        [Fact]
        public void PostNewPersonReturnsNewPersonTest()
        {
            var entityRequest = _fixture.Create<Person>();

            var person = _classUnderTest.AddPerson(entityRequest);

            person.Should().BeEquivalentTo(entityRequest);
        }

        [Fact]
        public void UpdatePersonGatewayTest()
        {
            var entity = _fixture.Create<Person>();
            var databaseEntity = DatabaseEntityHelper.CreateDatabaseEntityFrom(entity.ToDatabase());


            DatabaseContext.Add(databaseEntity);
            DatabaseContext.SaveChanges();

            entity.FirstName = "Test";

            var person = _classUnderTest.UpdatePerson(entity);

            person.FirstName.Should().Be(entity.FirstName);
        }

    }
}
