
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BFYOC
{
    public static class GetRatings
    {
        [FunctionName("GetRatings")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "users/{userId:int}/ratings")]HttpRequest req, int userId,
            [CosmosDB("Challenge2", "Ratings",
                ConnectionStringSetting = "CosmosDBConnectionString",
                SqlQuery = "select * from Ratings r where r.userId = {userId}")]
                IEnumerable<Rating> ratings,
            TraceWriter log
        )
        {
            

            //if (string.IsNullOrWhiteSpace(userId))
            //    return new BadRequestObjectResult("Must supply userId parameter");


            //validate user

            //load ratings

            

            return new OkObjectResult(ratings);
        }
    }
}
