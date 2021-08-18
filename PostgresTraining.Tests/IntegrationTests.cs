using System.Net.Http;
using PostgresTraining.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace PostgresTraining.Tests
{
    public class IntegrationTests<TStartup> where TStartup : class
    {
        protected HttpClient _client { get; private set; }
        protected DatabaseContext DatabaseContext { get; private set; }

        private MockWebApplicationFactory<TStartup> _factory;
        private NpgsqlConnection _connection;
        private NpgsqlTransaction _transaction;
        private DbContextOptionsBuilder _builder;

        public IntegrationTests()
        {
            _connection = new NpgsqlConnection(ConnectionString.TestDatabase());
            _connection.Open();
            var npgsqlCommand = _connection.CreateCommand();
            npgsqlCommand.CommandText = "SET deadlock_timeout TO 30";
            npgsqlCommand.ExecuteNonQuery();

            _builder = new DbContextOptionsBuilder();
            _builder.UseNpgsql(_connection);

            _factory = new MockWebApplicationFactory<TStartup>(_connection);
            _client = _factory.CreateClient();
            DatabaseContext = _factory.Server.Host.Services.GetRequiredService<DatabaseContext>();

            _transaction = _connection.BeginTransaction(IsolationLevel.RepeatableRead);
            DatabaseContext.Database.UseTransaction(_transaction);
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
                _disposed = true;
                if (_transaction != null)
                {
                    _transaction.Rollback();
                    _transaction.Dispose();
                }

                if (_factory != null)
                    _factory.Dispose();

                if (_client != null)
                    _client.Dispose();

                if (_connection != null)
                    _connection.Dispose();

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
