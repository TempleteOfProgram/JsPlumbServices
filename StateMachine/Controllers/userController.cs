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
    public class userController : Controller
    {
        [HttpGet]
        public JsonResult login(string username, string password)
        { // user/login?username=testuser&password=password
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
        public JsonResult signup([FromBody] User user)
        {  // user/signup  & body = {"usernma": "testuser", "password": "password" }
            Console.WriteLine(user);
            return Json("working");
        }
    }
}