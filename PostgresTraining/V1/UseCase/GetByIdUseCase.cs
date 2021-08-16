using PostgresTraining.V1.Boundary.Response;
using PostgresTraining.V1.Factories;
using PostgresTraining.V1.Gateways;
using PostgresTraining.V1.UseCase.Interfaces;

namespace PostgresTraining.V1.UseCase
{
    public class GetByIdUseCase : IGetByIdUseCase
    {
        private IExampleGateway _gateway;
        public GetByIdUseCase(IExampleGateway gateway)
        {
            _gateway = gateway;
        }

        public ResponseObject Execute(int id)
        {
            return _gateway.GetEntityById(id).ToResponse();
        }
    }
}
