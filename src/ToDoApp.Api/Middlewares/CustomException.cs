using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using ToDoApp.Application.ViewModel;

namespace ToDoApp.Api.Middlewares
{
    public class CustomException(ILogger<CustomException> logger) : IExceptionFilter
    {
        private readonly ILogger<CustomException> _logger = logger;

        public void OnException(ExceptionContext context)
        {
            ObjectResult objectResult;

            var contextException = context.Exception.InnerException ?? context.Exception;

            int statusCode = (int)HttpStatusCode.InternalServerError;
            string message = contextException.Message;

            // TODO: aqui s�o exemplos de possiveis custom  exception que o projeto ter, e se tiver tradu��o ser� necessario apontar o resource da mensagem no local da mensagem de erro
            if (contextException is UnauthorizedAccessException) { statusCode = (int)HttpStatusCode.Unauthorized; message = "Usu�rio sem autoriza��o"; }
            if (contextException is FormatException) { statusCode = (int)HttpStatusCode.UnsupportedMediaType; message = "formato incorreto"; }

            objectResult = new ObjectResult(new ErrorResponseVM(statusCode, message))
            {
                StatusCode = statusCode
            };
            context.Result = objectResult;
        }

    }
}
