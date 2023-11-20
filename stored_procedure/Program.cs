using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Connection string for the SQL Server database
        string connectionString = "Data Source=Amaze\\SQLEXPRESS;Initial Catalog=things_to_do;Integrated Security=True";

        // Create a SqlConnection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Create a SqlCommand for the stored procedure
            using (SqlCommand command = new SqlCommand("OutputAllItems", connection))
            {
                // Specify that the command is a stored procedure
                command.CommandType = CommandType.StoredProcedure;

                // Execute the stored procedure
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Check if there are rows returned
                    if (reader.HasRows)
                    {
                        Console.WriteLine("Products:");
                        while (reader.Read())
                        {
                            // Access columns using reader
                            int itid = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            

                            Console.WriteLine($"ProductID: {itid}, ProductName: {name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No products found.");
                    }
                }
            }
        }
    }
}

