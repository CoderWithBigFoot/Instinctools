using System.Data.Common;
using System.Data.Entity.Infrastructure;

namespace ZKorsakas.Data.EntityFramework.Tests.ProviderFactories
{
    public class EffortProviderFactory : IDbConnectionFactory
    {
        private static DbConnection _connection;
        private readonly static object _lock = new object();

        public EffortProviderFactory() { }

        public static void ResetDb()
        {
            lock (_lock)
            {
                _connection = null;
            }
        }

        public DbConnection CreateConnection(string nameOrConnectionString)
        {
            lock (_lock)
            {
                if (_connection == null)
                {
                    _connection = Effort.DbConnectionFactory.CreateTransient();
                }
                return _connection;
            }
        }
    }
}
