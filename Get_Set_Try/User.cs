using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlTypes;

namespace Get_Set_Try
{
    
        public class Users
        {

        int _Rid;
            public int  RID
            {
                get { return _Rid; }
                set { _Rid = value; }
            }
            string _UName;
            public string Username
            {
                get { return _UName; }
                set { _UName = value; }
            }
            string _Pass;
            public string Password
            {
                get { return _Pass; }
                set { _Pass = value; }
            }
        }

    
}
