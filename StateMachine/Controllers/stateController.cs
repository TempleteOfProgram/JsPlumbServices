using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using StateMachine.Models;
using StateMachine.Services;

namespace StateMachine.Controllers
{
    [Route("workflow/")]
    [ApiController]
    public class stateController : Controller
    {
        private DbService dbservice = new DbService();

        [HttpGet]
        [Route("")]
        public JsonResult welocme()
        {
            //Console.WriteLine(this.dbservice);
            var response = new Status
            {
                code = 200,
                message = $"welcome to workflow api."
            };
            return Json(response);
        }

        [HttpGet]
        [Route("getWorkflow")]
        public JsonResult getWorkflow(int id)
        {
            
            var response = this.dbservice.GetWorkflow(id);
            if (response.Count() == 0)
            {
                var res = new Status
                {
                    code = 404,
                    message = "workflow not found"
                };
                return Json(res);
            }
            else
            {
                return Json(response.FirstOrDefault());
            }   
        }

        [HttpPut]
        [Route("SaveWorkflow")]
        public JsonResult SaveWorkflow([FromBody] WorkflowModel model)
        {
            this.dbservice.SaveWorkflow(model);
            // return Json("State has been Added");
            var response = new Status
            {
                code = 200,
                message=$"workflow {model.WorkflowId} saved successfully."
            };
            return Json(response) ;
        }
        
        
        [HttpDelete]
        [Route("deleteWorkflow")]
        public JsonResult deleteWorkflow(int id)
        {
            this.dbservice.deleteWorkflow(id);
            var response = new Status
            {
                code = 200,
                message = $"workflow deleted where id = {id}."
            };
            return Json(response);
        }

        [HttpGet]
        [Route("AllWorkflows")]
        public JsonResult GetWorkflowName()
        {
            var response = this.dbservice.GetWorkflowNames();
            if (response.Count() == 0)
            {
                var res = new Status
                {
                    code = 404,
                    message = "workflow not found"
                };
                return Json(res);
            }
            else
            {
                return Json(response);
            }
        }
        /**
        [HttpPut]
        [Route("updateWorkflow")]
        public JsonResult updateWorkflow([FromBody] WorkflowModel model)
        {
            this.dbservice.updateWorkflow(model);
            // Console.WriteLine(this.dbservice);
            var response = new Status
            {
                code = 200,
                message = $"workflow {model.WorkflowId} updated successfully."
            };
            return Json(response);
        }
        **/


    }
}