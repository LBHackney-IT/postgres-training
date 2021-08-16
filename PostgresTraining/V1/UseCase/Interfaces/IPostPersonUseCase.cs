using PostgresTraining.V1.Boundary.Request;
using PostgresTraining.V1.Boundary.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresTraining.V1.UseCase.Interfaces
{
    public interface IPostPersonUseCase
    {
        ResponseObject Execute(PersonRequestObject createPersonRequestObject);
    }
}
