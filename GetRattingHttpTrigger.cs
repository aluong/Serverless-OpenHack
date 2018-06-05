
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace BFYOC
{
    public static class GetRattingHttpTrigger
    {
        [FunctionName("GetRattingHttpTrigger")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("Request for Get Ratting Http Trigger.");

            string ratingId = req.Query["ratingId"];

            if (ratingId == null) new BadRequestObjectResult("Please Enter RattingID");

            return (ActionResult)new OkObjectResult($"The product name for your product id {ratingId} is Starfruit Explosion");
        }
    }
}
