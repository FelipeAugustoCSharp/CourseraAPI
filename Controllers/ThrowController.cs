using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ThrowController : ControllerBase
    {
        [Route("/error")]
        public IActionResult HandleError() => 
            Problem();

        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment([FromBody] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandleFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return Problem(
                detail: exceptionHandleFeature.Error.StackTrace,
                title: exceptionHandleFeature.Error.Message);
        }
    }
}
