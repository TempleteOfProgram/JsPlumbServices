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
    [Route("state/")]
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

        [HttpPost]
        [Route("SaveWorkflow")]
        public JsonResult SaveWorkflow([FromBody] WorkflowModel model)
        {
            this.dbservice.SaveWorkflow(model);
            return Json("State has been Added");
        }


        [HttpGet]
        [Route("getWorkflow")]
        public JsonResult getWorkflow()
        {
            string query = "SELECT* FROM dbo.Workflow";
            Console.WriteLine(this.dbservice.GetWorkflow(query));
            return Json("working");
            //return Ok(this.dbservice.GetWorkflow(query));
        }

        /**
        [HttpGet]
        [Route("getState")]
        public IActionResult States()
        {
            string query = "SELECT* FROM dbo.Nodes";
            return Ok(this.dbservice.GetStates(query));
        }
        **/
    }
}