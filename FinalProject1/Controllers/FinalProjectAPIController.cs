using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalProjectAPIController : ControllerBase
    {
        // GET: api/<FinalProjectAPIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FinalProjectAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FinalProjectAPIController>
        [HttpPost]
        public string Post([FromBody]object value)
        {
            return "post string value = " + value;
        }

        // PUT api/<FinalProjectAPIController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]object value)
        {
            return "post string value = " + value;
        }

        // DELETE api/<FinalProjectAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
