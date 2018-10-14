using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Mailer.Functions
{
    public static class HandleSendMail
    {
        [FunctionName("HandleSendMail")]
        public static void Run([QueueTrigger("mailerqueue", Connection = "DefaultEndpointsProtocol=https;AccountName=mailerstoragetest;AccountKey=eL9PgdasceG8Nfd3imXNs8EGt4l9+Le5Mx0i2Qc1crgohUtFiaK4vwW+vEXa44axlbx2YNR1PX3SIOG0rQcXEg==;EndpointSuffix=core.windows.net")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
