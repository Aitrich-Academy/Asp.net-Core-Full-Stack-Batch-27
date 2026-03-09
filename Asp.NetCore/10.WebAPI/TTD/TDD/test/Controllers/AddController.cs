using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.NewFolder;

namespace test.Controllers
{
 
    [ApiController]
    public class AddController : BaseApiController<AddController>
    {
        [HttpPost]
        [Route("add")]
        public IActionResult Add(Data ob)
        {

            int result = ob.a + ob.b;
            if (ob.a == 2) {
                return BadRequest();

            }
            else
            {
                return Ok(result);
            }

          

        }
    }
}
