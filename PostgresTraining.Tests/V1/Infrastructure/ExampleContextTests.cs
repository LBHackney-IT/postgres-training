using System.Linq;
using PostgresTraining.Tests.V1.Helper;
using Xunit;

namespace PostgresTraining.Tests.V1.Infrastructure
{
    public class DatabaseContextTest : DatabaseTests<Startup>
    {
        [Fact]
        public void CanGetADatabaseEntity()
        {
            var databaseEntity = DatabaseEntityHelper.CreateDatabaseEntity();

            DatabaseContext.Add(databaseEntity);
            DatabaseContext.SaveChanges();

            var result = DatabaseContext.Persons.ToList().FirstOrDefault();

            //Assert.AreEqual(result, databaseEntity);
        }
    }
}
