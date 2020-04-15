using System;
using System.Data;
using System.Data.SqlClient;

namespace Northwind_AdoDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // connection string
            string connection = "server=./; Trusted_Connection=yes;database=Northwind";

            // sql query
            string query = "SELECT e.FirstName, e.LastName FROM Employees e " +
                "join EmployeeTerritories et on e.EmployeeID = et.EmployeeID " +
                "join Territories t on et.TerritoryID = t.TerritoryID " +
                "join Region r on t.RegionID = r.RegionID WHERE r.RegionID = 1";

            string query2 = "select e.FirstName, e.LastName " +
 "from Employees e " +
 "join EmployeeTerritories et on " +
 "e.EmployeeID = et.EmployeeID " +
 "join Territories t on et.TerritoryID = " +
 "t.TerritoryID " +
 "join Region r on t.RegionID = " +
 "r.RegionID " +
 "where r.RegionID = 1";

            // create Data Adapter to connect with application and database
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(query, connection);

            // Data Set is used as subset of retrieved data can be used to view or manipulate data
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet);

            // Retrieve the orders table
            DataTable myDataTable = myDataSet.Tables[0];

            foreach(DataRow dataRow in myDataTable.Rows)
            {
                Console.WriteLine("Product ID: {0} and Name: {1}",
                    dataRow["FirstName"], dataRow["LastName"]);
            }

        }
    }
}
