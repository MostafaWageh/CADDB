using Autodesk.AutoCAD.Runtime;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADDB
{
    public class DBUtil
    {
        [CommandMethod("MWITI")]
        public static void DBRun()
        {
            Main main = new Main();
            main.ShowDialog();

        }
        public static SqlConnection GetConnection()
        {
            string connStr = Settings1.Default.connstr;
            SqlConnection conn = new SqlConnection(connStr);    
            return conn;

        }

    }
}
