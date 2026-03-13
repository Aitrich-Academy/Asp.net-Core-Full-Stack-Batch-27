using Microsoft.AspNetCore.Mvc;

namespace PawConnect.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}
