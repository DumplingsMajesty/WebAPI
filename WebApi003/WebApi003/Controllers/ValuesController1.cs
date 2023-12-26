using Microsoft.AspNetCore.Mvc;
using WebApi003.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi003.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController1 : ControllerBase
    {
        private readonly IConfiguration _config;

        public ValuesController1(IConfiguration configuration)
        {
            this._config = configuration;
        }


        // GET: api/<ValuesController1>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id1}/{id2}")]
        public string Get1(int id1,int id2)
        {
            return "value";
        }

        // POST api/<ValuesController1>
        [HttpPost(template: "{value2}")]
        public void Post([FromBody] string value1, [FromRoute] string value2, [FromHeader] string value3)
        {
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public void Post([FromBody] ValuesModel value1)
        {
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [NonAction]
        public void Test()
        {
        }
    }
}
