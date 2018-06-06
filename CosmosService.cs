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
            // Set unique id
            var id = Guid.NewGuid();

            var order = new Order
            {
                id = Guid.NewGuid()

            };
            await document.AddAsync(order);

            return order;
        }
    }
}