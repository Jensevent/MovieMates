using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMates_Backend.Controllers
{
    [Route("")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public ActionResult WelcomeMessage()
        {
            return Ok("Thank you for using moviemates!");
        }
    }
}
