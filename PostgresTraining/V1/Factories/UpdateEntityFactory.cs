using PostgresTraining.V1.Boundary.Request;
using PostgresTraining.V1.Domain;
using PostgresTraining.V1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PostgresTraining.V1.Factories
{
    public static class UpdateEntityFactory
    {
        public static PersonEntity ToDatabase(this PersonRequestObject personRequestObject)
        {
            return new PersonEntity
            {
                DateOfBirth = personRequestObject.DateOfBirth,
                FirstName = personRequestObject.FirstName,
                Id = personRequestObject.Id,
                MiddleName = personRequestObject.MiddleName,
                PlaceOfBirth = personRequestObject.PlaceOfBirth,
                Surname = personRequestObject.Surname,
                Title = personRequestObject.Title
            };
        }

        public static Person ToDomain(this PersonRequestObject person)
        {
            return new Person
            {
                DateOfBirth = person.DateOfBirth,
                FirstName = person.FirstName,
                Id = person.Id,
                MiddleName =person.MiddleName,
                PlaceOfBirth = person.PlaceOfBirth,
                Surname = person.Surname,
                Title = person.Title
            };
        }
    }
}
