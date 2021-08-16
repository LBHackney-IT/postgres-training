using System.Collections.Generic;
using PostgresTraining.V1.Boundary.Request;
using PostgresTraining.V1.Domain;

namespace PostgresTraining.V1.Gateways
{
    public interface IExampleGateway
    {
        Person GetEntityById(int id);
        Person AddPerson(Person person);

        Person UpdatePerson(Person person);

    }
}
