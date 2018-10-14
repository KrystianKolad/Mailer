using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Mailer.Functions
{
    public static class HandleSayHello
    {
        [FunctionName("HandleSayHello")]
        public static void Run([QueueTrigger("mailerqueue")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
