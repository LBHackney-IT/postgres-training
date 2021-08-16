using System.Net.Http;
using PostgresTraining.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql;
using Xunit;

namespace PostgresTraining.Tests
{
    public class IntegrationTests<TStartup> where TStartup : class
    {
        protected HttpClient Client { get; private set; }
        protected DatabaseContext DatabaseContext { get; private set; }

        private MockWebApplicationFactory<TStartup> _factory;
        private NpgsqlConnection _connection;
        private IDbContextTransaction _transaction;
        private DbContextOptionsBuilder _builder;

        public void OneTimeSetUp()
        {
            _connection = new NpgsqlConnection(ConnectionString.TestDatabase());
            _connection.Open();
            var npgsqlCommand = _connection.CreateCommand();
            npgsqlCommand.CommandText = "SET deadlock_timeout TO 30";
            npgsqlCommand.ExecuteNonQuery();

            _builder = new DbContextOptionsBuilder();
            _builder.UseNpgsql(_connection);

        }

        public IntegrationTests()
        {
            _factory = new MockWebApplicationFactory<TStartup>(_connection);
            Client = _factory.CreateClient();
            DatabaseContext = new DatabaseContext(_builder.Options);
            DatabaseContext.Database.EnsureCreated();
            _transaction = DatabaseContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                if (null != _transaction)
                    _transaction.Dispose();
                _disposed = true;

                if (null != _factory)
                    _factory.Dispose();
                _disposed = true;

                if (null != Client)
                    Client.Dispose();
                _disposed = true;
            }
        }
    }
    [CollectionDefinition("Integration collection", DisableParallelization = true)]
    public class IntegrationCollection : ICollectionFixture<IntegrationTests<Startup>>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
