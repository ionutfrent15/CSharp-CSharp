using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace Server.utils
{
    class SqliteConnectionFactory : ConnectionFactory
    {
        public override IDbConnection createConnection(IDictionary<string, string> props)
        {
            string connectionString = "Data Source=ConcursInot.db;Version=3";
            return new SQLiteConnection(connectionString);
        }
    }
}
