using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using client.project.web.host.Models;

namespace client.project.web.host.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult Login([FromBody]LoginDTO loginDTO)
        {
            int userId = loginDTO.UserName == "admin" ? 1 : 2;

            var data = new 
            {
                code = 200,
                message = "OK",
                userId = userId,
                apiToken = new {
                    access_token = "7658-adsf76987-asd768",
                    refresh_token = "cvx769adf",
                    //".expires" = ""
                }
            };

            return new ObjectResult(data);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            var data = new 
            {
                code = 200,
                message = "OK"
            };

            return new ObjectResult(data);
        }

        [HttpGet]
        public IActionResult GetUserData(int id)
        {
            bool isAdmin = id == 1;

            var data = new 
            {
                code = 200,
                message = "OK",
                sessionId = "76987-we-1234-sdfad",
                userName = "Tom",
                userId = id,
                firstName = "Tom",
                lastName = "Cruise",        
                isAdmin = isAdmin
            };

            return new ObjectResult(data);
        }
       
    }
}
