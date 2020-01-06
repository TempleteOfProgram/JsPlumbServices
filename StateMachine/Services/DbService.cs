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
            data = JsonConvert.SerializeObject(model.JSON).Replace("'", "\"");
            query = "INSERT INTO dbo.Workflow (WorkflowId, Name, Description, JSON, CreatedOn)";
            sSQL = query + $"VALUES({model.WorkflowId}, '{model.Name}', '{model.Description}','{data}', '{DateTime.Now}')";
            Console.WriteLine(sSQL);
            **/
            if (model.WorkflowId > 0)
            {   // update an existing workflow
                //sSQL = "UPDATE dbo.tusharWorkflow SET JSON = '" + model.JSON + "' WHERE WorkflowId = " + model.WorkflowId.ToString() + "";
                data = JsonConvert.SerializeObject(model.JSON).Replace("'", "\"");
                sSQL = $"UPDATE dbo.Workflow SET Name= '{model.Name}' , Description= '{model.Description}', JSON='{data}', UpdatedOn='{DateTime.Now}' WHERE WorkflowId= {model.WorkflowId}";
            }
            else
            {   // create a new workflow
                //sSQL = "INSERT INTO dbo.tusharWorkflow (workflowID,data) VALUES ('" + model + "')";
                data = JsonConvert.SerializeObject(model.JSON).Replace("'", "\"");
                query = "INSERT INTO dbo.Workflow (Name, Description, JSON, CreatedOn)";
                sSQL = query + $"VALUES( '{model.Name}', '{model.Description}','{data}', '{DateTime.Now}')";   
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
            string query = $"SELECT * FROM dbo.tusharWorkflow where workflowID = {id}";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
               var WorkflowModel_ = new WorkflowModel
               {
                   WorkflowId = reader.GetInt32(0),
                   JSON = reader.GetString(1),
       
               };
               output.Add(WorkflowModel_);
            }
            sqlConnection.Close();
            return output;
        }

        
        public bool deleteWorkflow(int id)
        {
            bool bValid = false;
            string sSQL = string.Empty;
            sSQL = $"DELETE FROM dbo.tusharWorkflow WHERE WorkflowId = {id}";
            Console.WriteLine(sSQL);

            sqlConnection.Open();
            SqlCommand command = new SqlCommand(sSQL, sqlConnection);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            bValid = true;

            return bValid;
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
