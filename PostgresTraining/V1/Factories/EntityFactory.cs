using PostgresTraining.V1.Domain;
using PostgresTraining.V1.Infrastructure;
using System;

namespace PostgresTraining.V1.Factories
{
    public static class EntityFactory
    {
        public static Person ToDomain(this PersonEntity databaseEntity)
        {

            return new Person
            {
                Id = databaseEntity.Id,
                DateOfBirth = databaseEntity.DateOfBirth,
                FirstName = databaseEntity.FirstName,
                MiddleName = databaseEntity.MiddleName,
                Surname = databaseEntity.Surname,
                PlaceOfBirth = databaseEntity.PlaceOfBirth,
                Title = databaseEntity.Title
            };
        }

        public static PersonEntity ToDatabase(this Person entity)
        {

            return new PersonEntity
            {
                Id = entity.Id,
                DateOfBirth = entity.DateOfBirth,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                Surname = entity.Surname,
                PlaceOfBirth = entity.PlaceOfBirth,
                Title = entity.Title
            };
        }
    }
}
