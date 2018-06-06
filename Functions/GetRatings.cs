using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Collections.Generic;
using System.Linq;

namespace BFYOC
{
    public static class GetRatings
    {
        [FunctionName("GetRatings")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ratings")]HttpRequest req,
            [CosmosDB("Challenge2", "Ratings",
                ConnectionStringSetting = "CosmosDBConnectionString",
                SqlQuery = "select * from Ratings")]
                IEnumerable<Rating> ratings,
            TraceWriter log
        )
        {
            int limit;

            if(int.TryParse(req.Query["limit"], out limit))
            {
                return new OkObjectResult(ratings.Take(limit));
            }

            return new OkObjectResult(ratings);
        }
    }
}
