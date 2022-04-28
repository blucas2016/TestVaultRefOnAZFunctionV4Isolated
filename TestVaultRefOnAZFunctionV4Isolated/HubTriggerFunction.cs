using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace TestVaultRefOnAZFunctionV4Isolated
{
    public class HubTriggerFunction
    {
        private readonly ILogger _logger;

        public HubTriggerFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HubTriggerFunction>();
        }

        [Function("HubTriggerFunction")]
        public void Run([EventHubTrigger("samples-workitems", Connection = "Hub1ConnString")] string[] input)
        {
            _logger.LogInformation($"First Event Hubs triggered message: {input[0]}");
        }
    }
}
