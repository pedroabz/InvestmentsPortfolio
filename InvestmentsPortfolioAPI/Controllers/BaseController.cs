using InvestmentsPortfolioAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace InvestmentsPortfolioAPI.Controllers
{
    [ApiController]
    [ApplicationExceptionFilter]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
    }
    public class ApplicationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case BadRequestException e:
                    context.Result = new BadRequestObjectResult(e.Message);
                    return;
                case EntityNotFoundException e:
                    context.Result = new NotFoundObjectResult(e.Message);
                    return;
            }
        }
    }
    
}
