using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Get_Set_Try
{

    class Person
    {


        class Kisi
        {
            int _ıd;
            public int Id
            {
                get { return _ıd; }
                set { _ıd = value; }
            }


            string _Name;
            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }


            string _surname;
            public string surname
            {
                get { return _surname; }
                set { _surname = value; }
            }


            int _age;
            public int age
            {
                get { return _age; }
                set { _age = value; }
            }






        }
    }
}
