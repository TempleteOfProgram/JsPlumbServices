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

        public List<State> GetStates()
        {
            List<State> output = new List<State>();
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.State", sqlConnection);
            sqlConnection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var state = new State
                {
                    StateId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    IsActive = reader.GetBoolean(3)
                };
                output.Add(state);
            }
            sqlConnection.Close();
            return output;
        }
    }
}
