using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Mime;
using System.Net;
using System.Linq;
using ToDoApp.Application.ViewModel;

namespace ToDoApp.Api.Middlewares
{
    public class ValidateModelStateFilterAttribute(ILogger<ValidateModelStateFilterAttribute> logger) : ActionFilterAttribute
    {
        private readonly ILogger<ValidateModelStateFilterAttribute> _logger = logger;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(p => p.Errors.Count > 0)
                                                  .SelectMany(p => p.Errors)
                                                  .Select(p => p.ErrorMessage)
                                                  .ToList();
                context.Result = new BadRequestObjectResult(new ErrorResponseVM((int)HttpStatusCode.BadRequest, "", errors));

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
            }
        }
    }
}
