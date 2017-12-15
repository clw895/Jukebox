using Twilio.TwiML;
using Twilio.TwiML.Messaging;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace JukeboxFunctions
{
    public static class Function1
    {
        [FunctionName("ReplyToJukeboxRequest")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var twilioResponse = new MessagingResponse();
            twilioResponse.Append(new Message("Thanks for sending your request. We will reply to your request shortly"));

            return new ContentResult{ Content = twilioResponse.ToString(), ContentType = "application/xml" };
        }
    }
}
