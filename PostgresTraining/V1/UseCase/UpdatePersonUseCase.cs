using PostgresTraining.V1.Boundary.Request;
using PostgresTraining.V1.Boundary.Response;
using PostgresTraining.V1.Factories;
using PostgresTraining.V1.Gateways;
using PostgresTraining.V1.UseCase.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresTraining.V1.UseCase
{
    public class UpdatePersonUseCase : IUpdatePersonUseCase
    {
        private readonly IExampleGateway _gateway;

        public UpdatePersonUseCase(IExampleGateway gateway)
        {
            _gateway = gateway;
        }

        public ResponseObject Execute(PersonRequestObject updatePersonRequestObject)
        {
            var result = _gateway.UpdatePerson(updatePersonRequestObject.ToDomain());
            return result.ToResponse();
        }
    }
}
