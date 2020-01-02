using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StateMachine.Models;

//using Newtonsoft.Json;

namespace StateMachine.Controllers
{

    [Route("/user")]
    public class userController : Controller
    {
        [HttpGet]
        [Route("login")]
        public JsonResult login(string username, string password)
        { // https://localhost:5001/user/login?username=testuser&password=password
            if (username == null || password == null)
            {
                return Json("username or password not provided");
            }
            else
            {
                Models.User user = new Models.User()
                {
                    username = username,
                    password = password
                };
                //var json = JsonConvert.SerializeObject(user);
                return Json(user);
            }
        }

        [HttpPost]
        [Route("signup")]
        public JsonResult signup([FromBody] User user)
        {  // https://localhost:5001/user/signup  & body = {"username": "testuser", "password": "password" }
            Console.WriteLine(user);
            return Json("working");
        }

        [HttpPut]
        [Route("update")]
        public JsonResult update([FromBody] User user)
        { // https://localhost:5001/user/update & body = {"username": "testuser", "password": "password" }
            Console.WriteLine(user);
            return Json("update working");
        }


        [HttpDelete]
        [Route("delete")]
        public JsonResult delete(string username)
        {  // https://localhost:5001/user/delete?username=testuser1
            Console.WriteLine("deleting " + username);
            return Json("delete working");
        }

    }
}