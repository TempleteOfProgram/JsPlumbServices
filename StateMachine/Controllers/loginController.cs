using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace StateMachine.Controllers
{
    
    public class loginController : Controller
    {
        // login?username=testuser&password=password
        public JsonResult index(string username, string password)
        {
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
    }
}