using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace RPSService.Controllers
{
    [Route("api/[controller]")]
    [Controller]
    public class VersionController : ControllerBase
    {
        // GET api/version
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Get()
        {
            var v = "1.0.0";
            return Ok(v);
        }        
    }
}
