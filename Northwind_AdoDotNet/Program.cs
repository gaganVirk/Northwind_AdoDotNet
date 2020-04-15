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
            string query = "Select OrderDate, ShippedDate from Orders";

            // create Data Adapter to connect with application and database
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(query, connection);

            // Data Set is used as subset of retrieved data can be used to view or manipulate data
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet);

            // Retrieve the orders table
            DataTable myDataTable = myDataSet.Tables[0];

            foreach(DataRow dataRow in myDataTable.Rows)
            {
                Console.WriteLine("Orders date: {0} and shipped date: {1}",
                    dataRow["OrderDate"], dataRow["ShippedDate"]);
            }

        }
    }
}
