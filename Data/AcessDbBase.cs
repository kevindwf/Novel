using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.OleDb;

namespace Novel.Data
{
    public class AccessDbBase : IDbBase
    {
        DbCommand IDbBase.CreateCommand()
        {
            return new OleDbCommand();
        }
        DbConnection IDbBase.CreateConnection()
        {
            return new OleDbConnection();
        }
        DbDataAdapter IDbBase.CreateDataAdapter()
        {
            return new OleDbDataAdapter();
        }
        DbParameter IDbBase.CreateParameter()
        {
            return new OleDbParameter();
        }
        public string Pre;
        public AccessDbBase()
        {
            Pre = string.Empty;
            DbHelper.Provider = this;
        }
    }
}
