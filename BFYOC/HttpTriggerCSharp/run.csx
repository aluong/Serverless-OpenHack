#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static IActionResult Run(HttpRequest req, TraceWriter log)
{
    log.Info("C# HTTP trigger function processed a request.");

    string productId = req.Query["productId"];

    return productId != null
        ? (ActionResult)new OkObjectResult($"The product name for your product id {productId} is Starfruit Explosion")
        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
}
