
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Mailer.Functions
{
    public static class SendMail
    {
        [FunctionName("SendMail")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, 
            [Queue("mailerqueue")] ICollector<string> destinationQueue, 
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            if(JsonConvert.DeserializeObject<EmailMessage>(requestBody) == null)
            {
                return new BadRequestResult();
            }

            destinationQueue.Add(requestBody);

            return new AcceptedResult();
        }
    }
}
