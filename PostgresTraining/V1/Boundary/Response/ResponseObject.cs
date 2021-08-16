using PostgresTraining.V1.Domain;
using System;

namespace PostgresTraining.V1.Boundary.Response
{
    public class ResponseObject
    {
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string MiddleName {get; set;}
        public string Surname {get; set;}
        public Title Title {get; set;}
        public string PlaceOfBirth {get; set;}
        public DateTime? DateOfBirth {get; set;}
    }
}
