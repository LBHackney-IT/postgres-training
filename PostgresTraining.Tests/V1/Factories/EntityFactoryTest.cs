using AutoFixture;
using PostgresTraining.V1.Domain;
using PostgresTraining.V1.Factories;
using PostgresTraining.V1.Infrastructure;
using FluentAssertions;
using NUnit.Framework;
using Xunit;

namespace PostgresTraining.Tests.V1.Factories
{
    public class EntityFactoryTest
    {
        private readonly Fixture _fixture = new Fixture();

        //TODO: add assertions for all the fields being mapped in `EntityFactory.ToDomain()`. Also be sure to add test cases for
        // any edge cases that might exist.
        [Fact]
        public void CanMapADatabaseEntityToADomainObject()
        {
            var databaseEntity = _fixture.Create<PersonEntity>();
            var entity = databaseEntity.ToDomain();

            databaseEntity.Id.Should().Be(entity.Id);
        }

        //TODO: add assertions for all the fields being mapped in `EntityFactory.ToDatabase()`. Also be sure to add test cases for
        // any edge cases that might exist.
        [Fact]
        public void CanMapADomainEntityToADatabaseObject()
        {
            var entity = _fixture.Create<Person>();
            var databaseEntity = entity.ToDatabase();

            entity.Id.Should().Be(databaseEntity.Id);
        }
    }
}
