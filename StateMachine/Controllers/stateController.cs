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
            Console.WriteLine(this.dbservice);
            return Json("Welcome to state-machine api");
        }

        [HttpPut]
        [Route("getWorkflow")]
        public JsonResult getWorkflow(int id)
        {
            return Json(this.dbservice.GetWorkflow(id));
        }

        [HttpPost]
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
            return Json($"workflow deleted where id = {id}");
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