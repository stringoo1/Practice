using System;
using System.Data.SqlClient;

namespace StoreSystem.Database
{
    public abstract class BaseAccessor : IDisposable
    {
        // SQLコネクション
        private SqlConnection con;

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
