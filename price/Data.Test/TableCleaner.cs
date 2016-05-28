using Data.Generic;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Data.Test
{
    public class TableCleaner
    {
        public void ClearAllTables(ISession session)
        {
            var types =
                typeof(IGenericEntity).Assembly.GetTypes().Where(
                    type => typeof(IGenericEntity).IsAssignableFrom(type) &&
                    !type.IsAbstract)
                    .ToArray();

            RunSqlNonQuery(session, "SET foreign_key_checks = 0;");
            RunSqlNonQuery(session, "Delete from items");
            RunSqlNonQuery(session, "Delete from prices");
            session.Flush();
            RunSqlNonQuery(session, "SET foreign_key_checks = 1;");
        }

        private List<int> GetList(int n)
        {
            List<int> result = new List<int>();
            for(int i = 1; i <= n; i++)
            {
                result.Add(i);
            }
            return result;
        }

        protected void RunSqlNonQuery(ISession session, string sql)
        {
            var cmd = session.Connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = 120;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            session.Flush();
        }
    }
}
