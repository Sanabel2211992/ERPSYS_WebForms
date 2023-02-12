using System;
using DAL;

namespace ERPSYS.DAL
{
    public class CommonDB :IDisposable
    {
        public DBHelper Dbhelper = DBHelper.GetInstance("dbconstrX");

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}