using System;
using System.Data;
using System.Data.SqlClient;

namespace Northwind_AdoDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the data connection
            string connectionString = "server=./; Trusted_Connection=yes;database=Northwind";

            // create the string to hold the SQL command
            // to get records from the Customers table
            string commandString = "Select CompanyName, ContactName from Customers";

            // create the data adapter with the connection string and command
            SqlDataAdapter myDataAdapter = new SqlDataAdapter(commandString, connectionString);

            // Create and fill the DataSet object
            DataSet myDataSet = new DataSet();
            myDataAdapter.Fill(myDataSet);

            // Retrieve the Customers table
            DataTable myDataTable = myDataSet.Tables[0];

            // iterate over the rows collection and output the fields
            foreach(DataRow dataRow in myDataTable.Rows)
            {
                Console.WriteLine("CompanyName: {0}. Contact: {1}",
                    dataRow["CompanyName"], dataRow["ContactName"]);
            }

        }
    }
}
