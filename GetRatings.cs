
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BFYOC
{
    public static class GetRatings
    {
        [FunctionName("GetRatings")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            string userId = req.Query["userId"];

            if (string.IsNullOrWhiteSpace(userId))
                return new BadRequestObjectResult("Must supply userId parameter");

            var ratings = new List<Rating>();

            return new OkObjectResult(ratings);
        }
    }
}
