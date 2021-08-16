using PostgresTraining.V1.Boundary.Request;
using PostgresTraining.V1.Boundary.Response;
using PostgresTraining.V1.Domain;
using PostgresTraining.V1.Factories;
using PostgresTraining.V1.Gateways;
using PostgresTraining.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace PostgresTraining.V1.UseCase
{
    public class PostPersonUseCase : IPostPersonUseCase
    {
        private readonly IExampleGateway _gateway;

        public PostPersonUseCase(IExampleGateway gateway)
        {
            _gateway = gateway;
        }

        public ResponseObject Execute(PersonRequestObject createPersonRequestObject)
        {
            var person = new Person
            {
                DateOfBirth = createPersonRequestObject.DateOfBirth,
                FirstName = createPersonRequestObject.FirstName,
                Id = createPersonRequestObject.Id,
                MiddleName = createPersonRequestObject.MiddleName,
                PlaceOfBirth = createPersonRequestObject.PlaceOfBirth,
                Surname = createPersonRequestObject.Surname,
                Title = createPersonRequestObject.Title
            };

            var response = _gateway.AddPerson(person);
            return response.ToResponse();
        }
    }
}
