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
        [Route("updateState")]
        public JsonResult updateState([FromBody] User user)
        {
            Console.WriteLine(user);
            return Json("State has been successfully updated");
        }

        [HttpGet]
        [Route("getState")]
        public IActionResult States()
        {
            string query = "SELECT* FROM dbo.State";
            return Ok(this.dbservice.GetStates(query));
        }
    }
}