using System.Linq;
using PostgresTraining.V1.Boundary.Request;
using PostgresTraining.V1.Domain;
using PostgresTraining.V1.Factories;
using PostgresTraining.V1.Infrastructure;

namespace PostgresTraining.V1.Gateways
{
    public class ExampleGateway : IExampleGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ExampleGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Person GetEntityById(int id)
        {
            var result = _databaseContext.Persons.Find(id);
            return result?.ToDomain();

        }

        public Person AddPerson(Person person)
        {
            var newPerson = new Person
            {
                DateOfBirth = person.DateOfBirth,
                FirstName = person.FirstName,
                Id = person.Id,
                MiddleName = person.MiddleName,
                PlaceOfBirth = person.PlaceOfBirth,
                Surname = person.Surname,
                Title = person.Title
            };

            _databaseContext.Persons.Add(newPerson.ToDatabase());
            _databaseContext.SaveChanges();

            return newPerson;

        }

        public Person UpdatePerson(Person person)
        {
            var result = _databaseContext.Persons.Find(person.Id);
            if (result == null) return null;
            result = person.ToDatabase();

            _databaseContext.SaveChanges();

            return result.ToDomain();

        }
    }
}
