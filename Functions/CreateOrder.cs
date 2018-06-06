
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace BFYOC
{
 
    public static class CreateOrder
    {
        private static readonly HttpClient client = new HttpClient();

        [FunctionName("CreateOrder")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "ratings")]HttpRequest req,
            [CosmosDB(
                databaseName: "Challenge2",
                collectionName: "Orders",
                ConnectionStringSetting = "CosmosDBConnectionString")]
                IAsyncCollector<Rating> document,
            TraceWriter log)
        {
            try
            {
                log.Info("C# HTTP trigger function processed a request.");

                // Grab data from body
                string requestBody = new StreamReader(req.Body).ReadToEnd();
                dynamic data = JsonConvert.DeserializeObject(requestBody);



                // Validate OrderId
                if (data?.OrderID == null)
                {
                    return (ActionResult)new BadRequestObjectResult($"OrderId doesn't exists");
                }

                var andysCoolService = new CosmosService();

                var rating = await andysCoolService.CreateRatingFromDocument(data, document);


                return (ActionResult)new OkObjectResult(rating);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return (ActionResult)new BadRequestObjectResult("Error");
            }
        }
    }
}
