using Microsoft.AspNetCore.Mvc;
using Idea.API.Errors;

namespace Idea.API.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("api/errors/{code}")]
        [HttpGet]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}