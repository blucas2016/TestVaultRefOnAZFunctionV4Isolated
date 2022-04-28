using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace TestVaultRefOnAZFunctionV4Isolated
{
    public class HttpRequestFunction
    {
        private readonly ILogger _logger;

        public HttpRequestFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpRequestFunction>();
        }

        [Function("HttpRequestFunction")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            string name = Environment.GetEnvironmentVariable("Hub1ConnString");
            response.WriteString(name);

            return response;
        }
    }
}
