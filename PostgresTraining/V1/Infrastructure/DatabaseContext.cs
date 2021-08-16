using Microsoft.EntityFrameworkCore;

namespace PostgresTraining.V1.Infrastructure
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PersonEntity> Persons { get; set; }


    }
}
