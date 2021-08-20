using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace images
{
    class Controller
    {
        DBManager dbMan;

        public Controller()
        {
            dbMan = new DBManager(); // Create the DBManager Object
        }

        public int InsertData(string name, string address, string email)
        {
            string query = "INSERT INTO img (name,address,email) "
                       + "Values ('" + name + "','" + address + "','"+ email+"');";
            return dbMan.ExecuteNonQuery(query);
        }
    }
}
