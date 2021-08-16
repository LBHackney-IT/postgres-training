using AutoFixture;
using PostgresTraining.V1.Domain;
using PostgresTraining.V1.Infrastructure;

namespace PostgresTraining.Tests.V1.Helper
{
    public static class DatabaseEntityHelper
    {
        public static PersonEntity CreateDatabaseEntity()
        {
            var entitydb = new Fixture().Create<PersonEntity>();

            return CreateDatabaseEntityFrom(entitydb);
        }

        public static PersonEntity CreateDatabaseEntityFrom(PersonEntity entitydb)
        {
            return new PersonEntity
            {
                Id = entitydb.Id,
                DateOfBirth = entitydb.DateOfBirth,
                FirstName = entitydb.FirstName,
                MiddleName = entitydb.MiddleName,
                PlaceOfBirth = entitydb.PlaceOfBirth,
                Surname = entitydb.Surname,
                Title = entitydb.Title
            };
        }
    }
}
