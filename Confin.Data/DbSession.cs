using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Confin.Data
{
    public sealed class DbSession : IDbSession, IDisposable
    {
        private Guid _id = Guid.NewGuid();
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession()
        {
            Connection = new NpgsqlConnection(Environment.GetEnvironmentVariable("CONFIN_CONNECTION_STRING"));
        }
        
        public async Task<T> GetAsync<T>(string command, object parms)
        {
            return (await Connection.QueryAsync<T>(command, parms)
                        .ConfigureAwait(false))
                        .FirstOrDefault();
        }

        public async Task<List<T>> GetAll<T>(string command, object parms)
        {
            return (await Connection.QueryAsync<T>(command, parms)).ToList();
        }

        public async Task<T> Insert<T>(string command, object parms)
        {
            T result;
            result = Connection.Query<T>(command, parms, transaction: null, commandTimeout: 60, commandType: CommandType.Text).FirstOrDefault();

            return result;
        }

        public async Task<T> Update<T>(string command, object parms)
        {
            T result;
            result =  Connection.Query<T>(command, parms, transaction: null, commandTimeout:60,commandType :CommandType.Text).FirstOrDefault();
            return result;
        }

        public void Dispose() => Connection?.Dispose();
    }
}