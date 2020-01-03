using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StateMachine.Models;

using Newtonsoft.Json;

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

        public List<WorkflowModel> GetWorkflow(string query)
        {
            // string query = "SELECT* FROM dbo.Workflow";
            List<WorkflowModel> output = new List<WorkflowModel>();
            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            var reader = command.ExecuteReader();
            Console.WriteLine(reader.GetInt32(0)) ;
            /**
            while (reader.Read())
            {
                var WorkflowModel_ = new WorkflowModel
                {
                    JSON = reader.GetString(4),
                    WorkflowId = reader.GetInt32(1),
                };
                output.Add(WorkflowModel_);
            }
            **/
            sqlConnection.Close();
            return output;
        }

        public bool SaveWorkflow(WorkflowModel model)
        {
            bool bValid = false;

            string sSQL = string.Empty;
            /**
            if (model.WorkflowId > 0)
            {
                sSQL = "UPDATE dbo.tusharWorkflow SET JSON = '" + model + "' WHERE WorkflowId = " + model.WorkflowId.ToString() + "";
            }
            else
            {
                sSQL = "INSERT INTO dbo.tusharWorkflow (workflowID,data) VALUES ('" + model + "')";
            }
            **/
            var data = JsonConvert.SerializeObject(model.JSON).Replace("'", "\"");
            sSQL = $"INSERT INTO dbo.tusharWorkflow (workflowID,data) VALUES (5, '{data}')";
  
            sqlConnection.Open();            
            SqlCommand command = new SqlCommand(sSQL, sqlConnection);
            command.ExecuteNonQuery();             
            sqlConnection.Close();
            bValid = true;
            
            return bValid;
        }
    }
}
