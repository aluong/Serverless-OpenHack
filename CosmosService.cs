using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;

namespace BFYOC
{
    public class CosmosService
    {
        public async Task<Rating> CreateRatingFromDocument(dynamic data, IAsyncCollector<Rating> document)
        {
            // Set unique id
            var id = Guid.NewGuid();

            // Set Timestamp
            var timestamp = DateTime.UtcNow;

            var rand = new Random();

            var rating = new Rating
            {
                id = id,
                userId = data.userId,
                productId = data.productId,
                timestamp = timestamp,
                locationName = data.locationName,
                rating = data.rating,
                userNotes = data.userNotes,
                magicNumber = rand.Next()
            };

            await document.AddAsync(rating);

            return rating;
        }

        public async Task<Order> CreateOrderFromData(dynamic data, IAsyncCollector<Order> document)
        {

            var order = new Order
            {
                id = Guid.NewGuid(),
                productid = data.productid,
                productname = data.productname,
                productdescription = data.productdescription,
                ponumber = data.ponumber,
                quantity = data.quantity,
                unitcost = data.unitcost,
                totalcost = data.totalcost,
                totaltax = data.totaltax,
                OrderDate = data.OrderDate,
                LocationId = data.LocationId,
                locationname = data.locationname,
                locationaddress = data.locationaddress,
                locationpostcode = data.locationpostcode,
            };

            await document.AddAsync(order);

            return order;
        }
    }
}