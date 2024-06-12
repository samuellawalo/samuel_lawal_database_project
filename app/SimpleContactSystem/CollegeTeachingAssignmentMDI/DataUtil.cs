using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleContactSystem
{
    public static class DataUtil
    {
        public static int? GetInteger(DataRow dataRow, string ColumnName)
        {
            return dataRow[ColumnName] != DBNull.Value ? Convert.ToInt32(dataRow[ColumnName]) : null;
        }
    }
}
