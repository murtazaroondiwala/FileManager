using System.Net;
using System.Text.Json;
using FileManager.ViewModel.Infrastructure;

namespace FileManager.Server.Infrastructure;

public class ErrorHandlerMiddleware
{
    
    
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                //SerilogHelper.LogData("Error occured ", context.User.Identity.Name, context.Request.Path, SerilogHelper.LogLevel.ERROR, 0, null, "", "", ex);
                response.ContentType = "application/json";

                switch (ex)
                {
                    case AppException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = ex?.Message });
                await response.WriteAsync(result);
            }
        }
    }