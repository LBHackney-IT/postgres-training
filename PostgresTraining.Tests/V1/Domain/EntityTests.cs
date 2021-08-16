using System;
using PostgresTraining.V1.Domain;
using FluentAssertions;
using NUnit.Framework;
using Xunit;

namespace PostgresTraining.Tests.V1.Domain
{
    public class EntityTests
    {
        [Fact]
        public void EntitiesHaveAnId()
        {
            var entity = new Person();
            entity.Id.Should().BeGreaterOrEqualTo(0);
        }

        [Fact]
        public void EntitiesHaveACreatedAt()
        {
            var entity = new Person();
            var date = new DateTime(2019, 02, 21);

        }
    }
}
