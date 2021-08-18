using System;
using System.Collections.Generic;
using System.Linq;
using PostgresTraining.V1.Boundary.Response;
using PostgresTraining.V1.Domain;

namespace PostgresTraining.V1.Factories
{
    public static class ResponseFactory
    {
        public static ResponseObject ToResponse(this Person domain)
        {
            if (domain == null) return null;
            return new ResponseObject()
            {

                Id = domain.Id,
                DateOfBirth = domain.DateOfBirth,
                FirstName = domain.FirstName,
                MiddleName = domain.MiddleName,
                PlaceOfBirth = domain.PlaceOfBirth,
                Surname = domain.Surname,
                Title = domain.Title
            };
        }

    }
}
