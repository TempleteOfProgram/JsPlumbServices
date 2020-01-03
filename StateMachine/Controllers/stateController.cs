using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("getWorkflow")]
        public JsonResult getWorkflow(int id)
        {
            this.dbservice.GetWorkflow(id);
            return Json("working");
        }

        [HttpPost]
        [Route("SaveWorkflow")]
        public JsonResult SaveWorkflow([FromBody] WorkflowModel model)
        {
            this.dbservice.SaveWorkflow(model);
            return Json("State has been Added");
        }
        

        [HttpPut]
        [Route("updateWorkflow")]
        public JsonResult updateWorkflow([FromBody] WorkflowModel model)
        {
            this.dbservice.updateWorkflow(model);
            //Console.WriteLine(model.WorkflowId);
            return Json("State has been Updated");
        }

      
        
        [HttpDelete]
        [Route("deleteWorkflow")]
        public JsonResult deleteWorkflow(int id)
        {
            this.dbservice.deleteWorkflow(id);
            return Json("working");
        }
    

    }
}