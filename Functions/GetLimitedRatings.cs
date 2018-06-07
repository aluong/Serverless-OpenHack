using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Collections.Generic;

namespace BFYOC
{
    public static class GetLimitedRatings
    {
        [FunctionName("GetLimitedRatings")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ratings/limit/{limit:int}")]HttpRequest req,
            [CosmosDB("Challenge2", "Ratings",
                ConnectionStringSetting = "CosmosDBConnectionString",
                SqlQuery = "select top {limit} * from Ratings")]
                IEnumerable<Rating> ratings,
            TraceWriter log
        )
        {
            return new OkObjectResult(ratings);
        }
    }
}
