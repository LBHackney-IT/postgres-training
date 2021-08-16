using PostgresTraining.Tests.V1.Helper;
using System.Linq;
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

            Assert.Equal(result, databaseEntity);
        }
    }
}
