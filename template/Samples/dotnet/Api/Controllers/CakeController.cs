using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CakeController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            string cake = "Strawberry Shortcake";
            return new JsonResult(cake);
        }
    }

}
