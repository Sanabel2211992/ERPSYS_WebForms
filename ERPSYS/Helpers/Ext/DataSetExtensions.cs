using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ERPSYS.Helpers.Ext
{
    public static class DataSetExtensions
    {
        //Return whether DataSet contains DataRow(s) or not
        public static bool IsNullOrEmpty(this DataSet ds)
        {
            return (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0);
        }
    }
}