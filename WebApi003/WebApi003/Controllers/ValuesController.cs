using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi003.Models;

namespace WebApi003.Controllers
{
    //[Route("api/[controller]/abc")]
    [Route("api/v1/[controller]/abc")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("a/b/c")]
        public ValuesModel Test()
        {
            return new ValuesModel { Age = 1, Gender = "男", Name = "Tom", Id = 0001 };
        }

        [HttpGet]
        [Route("a1/b1/c1")]
        private ValuesModel PrivateTest()
        {
            return new ValuesModel { Age = 1, Gender = "男", Name = "Tom", Id = 0001 };
        }

        [HttpGet]
        [Route("[Action]")]
        public ValuesModel Action()
        {
            return new ValuesModel { Age = 1, Gender = "男", Name = "Tom", Id = 0001 };
        }
    }
}
