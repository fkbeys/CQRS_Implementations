namespace Sales.WebApi.MiddlewaresAndHelpers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Sales.Application.App_Wrappers.ResponseWrappers;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// With this class, we will be able to log the what s going on our system.
    /// This class will be worked as a middleware.
    /// So it will catch any request and response. 
    /// On the other hand, this class will catch any unhandled exceptions and will convert that exception to a standart response...
    /// So the user will be able to see what s the problem.
    /// </summary>
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseMiddleware> _logger;

        public RequestResponseMiddleware(RequestDelegate next, ILogger<RequestResponseMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Log incoming request
                var requestBody = await GetRequestBody(context.Request);
                var request = $"{context.Request.Method} {context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString} {requestBody}";
                _logger.LogInformation("Incoming Request: {0}", request);
            }
            catch (Exception ex)
            {
                _logger.LogError("InvokeAsync - GetRequestBody Error: {0}", ex.Message);
            }

            try
            {
                // Log outgoing response
                var originalBodyStream = context.Response.Body;

                using (var responseBodyStream = new MemoryStream())
                {
                    context.Response.Body = responseBodyStream;

                    try
                    {
                        await _next(context);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError("InvokeAsync - Error during processing: {0}", ex.Message);

                        context.Response.Clear();

                        context.Response.StatusCode = StatusCodes.Status404NotFound;
                        context.Response.ContentType = "application/json";

                        var error = new ServiceResponse<bool>(false)
                        {
                            isSuccess = false,
                            message = "Error! " + ex?.Message?.ToString() + "/" + ex?.InnerException?.Message
                        };

                        // Serialize the error response to JSON and write it to the response body
                        var jsonErrorResponse = JsonConvert.SerializeObject(error);
                        await context.Response.WriteAsync(jsonErrorResponse);
                    }

                    var responseBody = await GetResponseBody(context.Response);
                    var response = $"{context.Response.StatusCode} {responseBody}";
                    _logger.LogInformation("Outgoing Response: {0}", response);

                    await responseBodyStream.CopyToAsync(originalBodyStream);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("InvokeAsync - GetResponseBody Error: {0}", ex.Message);
            }
        }

        private async Task<string> GetRequestBody(HttpRequest request)
        {
            try
            {
                request.EnableBuffering();

                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                var bodyAsString = Encoding.UTF8.GetString(buffer);

                request.Body.Seek(0, SeekOrigin.Begin);

                return bodyAsString;
            }
            catch (Exception ex)
            {
                string message = $"GetRequestBody Error:{ex.Message}";
                _logger.LogError(message);
                return message;
            }
        }

        private async Task<string> GetResponseBody(HttpResponse response)
        {
            try
            {
                response.Body.Seek(0, SeekOrigin.Begin);

                using (var reader = new StreamReader(response.Body, Encoding.UTF8, leaveOpen: true))
                {
                    var text = await reader.ReadToEndAsync();
                    response.Body.Seek(0, SeekOrigin.Begin);
                    return text;
                }
            }
            catch (Exception ex)
            {
                string message = $"GetResponseBody Error:{ex.Message}";
                _logger.LogError(message);
                return message;
            }
        }
    }

}
