
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace BFYOC
{
    public static class GetProductHttpTrigger
    {
        [FunctionName("GetProductHttpTrigger")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string productId = req.Query["productId"];

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            productId = productId ?? data?.productId;

            return productId != null
                ? (ActionResult)new OkObjectResult($"The product name for your product id {productId} is Starfruit Explosion")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
