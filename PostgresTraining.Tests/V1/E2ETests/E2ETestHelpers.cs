using Bogus;
using PostgresTraining.Tests.V1.Helper;
using PostgresTraining.V1.Factories;
using PostgresTraining.V1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresTraining.Tests.V1.E2ETests
{
    public class E2ETestHelpers
    {
        public static PersonEntity AddPersonToDb(DatabaseContext context, int? id = null)
        {
            var person = TestHelper.CreateDatabasePersonEntity(id);
            context.Persons.Add(person.ToDatabase());
            var i = context.SaveChanges();

            return new PersonEntity
            {
                Id = person.Id,
                DateOfBirth = person.DateOfBirth,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                Surname = person.Surname,
                PlaceOfBirth = person.PlaceOfBirth,
                Title = person.Title
            };
        }
    }
}
