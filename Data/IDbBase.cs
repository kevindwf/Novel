using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Novel.Data
{
    public interface IDbBase
    {
        DbCommand CreateCommand();
        DbConnection CreateConnection();
        DbDataAdapter CreateDataAdapter();
        DbParameter CreateParameter();
    }
}
