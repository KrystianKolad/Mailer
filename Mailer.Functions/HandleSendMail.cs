using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Mail;
using Newtonsoft.Json;

namespace Mailer.Functions
{
    public static class HandleSendMail
    {
        [FunctionName("HandleSendMail")]
        public static void Run(
            [QueueTrigger("mailerqueue")]EmailMessage email,
            [SendGrid(ApiKey = "SendGridApiKey")] out SendGridMessage message,
            ILogger log)
        {
            log.LogInformation("Start sending email");

            message = new SendGridMessage();
            message.AddTo(email.To);
            message.AddContent("text/html",email.Body);
            message.SetSubject(email.Subject);

            message.SetFrom("mailer@test.pl"); // Change for your email

            log.LogInformation("Successfully send email");
        }
    }
    public class EmailMessage
    {
        public string To { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
