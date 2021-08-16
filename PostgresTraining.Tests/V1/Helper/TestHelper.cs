using AutoFixture;
using PostgresTraining.V1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresTraining.Tests.V1.Helper
{
    public class TestHelper
    {
        public static Person CreateDatabasePersonEntity(int? id = null)
        {
            var faker = new Fixture();
            var fp = faker.Build<Person>()
                .Without(p => p.Id)
                .Create();
            fp.DateOfBirth = new DateTime
                (fp.DateOfBirth.Value.Year, fp.DateOfBirth.Value.Month, fp.DateOfBirth.Value.Day);
            if (id != null) fp.Id = (int) id;

            return fp;
        }
    }
}
