using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace TestDapper.lib
{
    public class BaseRepository
    {
        public string? ConnectionString { get; set; }

        public SqlConnection CreateConnection(
            string connectionString = null, bool open = true,
            bool forceNoContext = false)
        {
            var con = new SqlConnection(
                connectionString ?? ConnectionString);
            if (open) con.Open();
            return con;
        }

        public static CommandDefinition CreateCommand(
            string commandText, object parameters = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null,
            CommandFlags flags = CommandFlags.Buffered,
            CancellationToken cancellationToken = default)
        {
            if (parameters != null)
                parameters = GetDynamicParameters(parameters);
            return new CommandDefinition(
                commandText, parameters, transaction,
                3600,
                commandType, flags, cancellationToken);
        }

        private static DynamicParameters GetDynamicParameters(object parameters)
        {
            var sqlMinDate = System.Data.SqlTypes.SqlDateTime.MinValue;
            var newParameters = new DynamicParameters();
            var paramsProperties = parameters.GetType().GetProperties();
            foreach (var p in paramsProperties)
            {
                var value = parameters.GetType().
                    GetProperty(p.Name).GetValue(parameters);
                if (p.PropertyType == typeof(DateTime))
                {
                    DateTime dateValue = Convert.ToDateTime(value);
                    if (dateValue <= sqlMinDate.Value) dateValue = sqlMinDate.Value;
                    newParameters.Add(p.Name, dateValue);
                }
                else if (p.PropertyType == typeof(Byte[]))
                {
                    newParameters.Add(p.Name, value, DbType.Binary);
                }
                else
                {
                    newParameters.Add(p.Name, value);
                }
            }
            return newParameters;
        }

    }
}
