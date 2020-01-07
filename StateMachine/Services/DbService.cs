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

        public bool SaveWorkflow(WorkflowModel model)
        {
            bool bValid = false;
            string sSQL = string.Empty;
            string data = string.Empty;
            string query = string.Empty;
            /**
            Console.WriteLine(model.Description);
            Console.WriteLine(model.Name);
            Console.WriteLine(model.JSON);
            **/
            if (model.WorkflowId > 0)
            {   // update an existing workflow
                //sSQL = "UPDATE dbo.tusharWorkflow SET JSON = '" + model.JSON + "' WHERE WorkflowId = " + model.WorkflowId.ToString() + "";
                sSQL = $"UPDATE dbo.Workflow SET Name= '{model.Name}' , Description= '{model.Description}', JSON='{model.Workflow}', UpdatedOn='{DateTime.Now}' WHERE WorkflowId= {model.WorkflowId} AND IsActive=1";
            }
            else
            {   // create a new workflow
                //sSQL = "INSERT INTO dbo.tusharWorkflow (workflowID,data) VALUES ('" + model + "')";
                data = model.Workflow.ToString();
                query = "INSERT INTO dbo.Workflow (Name, Description, JSON, CreatedOn, IsActive)";
                sSQL = query + $"VALUES( '{model.Name}', '{model.Description}','{model.Workflow}', '{DateTime.Now}', 1)";   
            }
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sSQL, sqlConnection);
            command.ExecuteNonQuery();
            sqlConnection.Close();
 
            bValid = true;
                return bValid;
            }
        public List<WorkflowModel> GetWorkflow(int id)
        {
            List<WorkflowModel> output = new List<WorkflowModel>();
            string query = $"SELECT * FROM dbo.Workflow where workflowID = {id} and IsActive=1";
            
            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
               var WorkflowModel_ = new WorkflowModel
               {
                   WorkflowId = reader.GetInt32(0),
                   Name= reader.GetString(1),
                   Description=reader.GetString(2),
                   Workflow = reader.GetString(3)
               };
               output.Add(WorkflowModel_);
            }
            sqlConnection.Close();
            // Console.WriteLine(output.Count());
            return output;
        }

        
        public bool deleteWorkflow(int id)
        {
            bool bValid = false;
            string sSQL = string.Empty;
            // sSQL = $"DELETE FROM dbo.Workflow WHERE WorkflowId = {id}";
            sSQL = $"UPDATE dbo.Workflow SET IsActive=0 WHERE WorkflowId= {id} AND IsActive=1";
  
            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sSQL, sqlConnection);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            bValid = true;

            return bValid;
        }

        public List<WorkflowModel> GetWorkflowNames()
        {
            List<WorkflowModel> output = new List<WorkflowModel>();
            string query = $"SELECT WorkflowId, Name, Description, JSON FROM dbo.Workflow";
  
            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var WorkflowModel_ = new WorkflowModel
                {
                    WorkflowId = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description= reader.GetString(2),
                    Workflow = reader.GetString(3)
                };
                output.Add(WorkflowModel_);
            }
            sqlConnection.Close();
            return output;
        }

        /**
        public bool updateWorkflow(WorkflowModel model)
        {
            bool bValid = false;

            string sSQL = string.Empty;
            var data = JsonConvert.SerializeObject(model.JSON).Replace("'", "\"");
            sSQL = $"UPDATE dbo.tusharWorkflow SET data = '{data}' WHERE WorkflowId = {model.WorkflowId}";

            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sSQL, sqlConnection);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            bValid = true;

            return bValid;
        }
        **/

    }
}
