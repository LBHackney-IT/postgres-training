using PostgresTraining.V1.Boundary.Response;

namespace PostgresTraining.V1.UseCase.Interfaces
{
    public interface IGetByIdUseCase
    {
        ResponseObject Execute(int id);
    }
}
