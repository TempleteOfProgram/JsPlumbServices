using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StateMachine.Models;

namespace StateMachine.Services
{
    public class DbService
    {
        readonly SqlConnection sqlConnection;
        readonly string connectionString = @"Data Source=DESKTOP-DSVBKRV\SQLEXPRESS;Initial Catalog=Workflow;Integrated Security=True";
        public DbService()
        {
            sqlConnection = new SqlConnection(connectionString);
            
        }

        public List<node> GetStates(string query)
        {
            // string query = "SELECT* FROM dbo.Nodes";
            List<node> output = new List<node>();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var Node = new node
                {
                    id = reader.GetString(0),
                    top = reader.GetInt32(1),
                    left = reader.GetInt32(2)
                };
                output.Add(Node);
            }
            sqlConnection.Close();
            return output;
        }
    }
}
