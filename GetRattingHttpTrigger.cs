
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Extensions.CosmosDB;
using Newtonsoft.Json;
using System;

namespace BFYOC
{
    public static class GetRattingHttpTrigger
    {
        [FunctionName("GetRattingHttpTrigger")]

        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "ratings/{ratingId}")]HttpRequest req,
             [CosmosDB(
                databaseName: "Challenge2",
                collectionName: "Ratings",
                ConnectionStringSetting = "CosmosDBConnectionString",
                Id = "{ratingId}")]dynamic rating, TraceWriter log)
        {
            log.Info("Request for Get Ratting Http Trigger.");

            string ratingId = req.Query["ratingId"];

            if (ratingId == null) return new BadRequestObjectResult("Please Enter RattingID");
                

           // var ratting = new Rating();

            return (ActionResult)new OkObjectResult(rating);
        }
    }

}
