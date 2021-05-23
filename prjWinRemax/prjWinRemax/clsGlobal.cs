using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace prjWinRemax
{
    class clsGlobal
    {
        //Declare global variables to access throughout the project
        public static DataSet mySet;
        public static SqlConnection myCon;
        public static SqlDataAdapter adpEmployees, adpClients, adpHouses;
    }
}
