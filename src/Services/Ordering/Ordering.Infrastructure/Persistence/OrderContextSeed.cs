﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
	public class OrderContextSeed
	{
		public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
			if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());

                await orderContext.SaveChangesAsync();

                logger.LogInformation("Seeded database associated with the context {DbContextName}", typeof(OrderContext).Name);
            }
        }

		private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() { UserName = "swn", FirstName = "Firat", LastName = "Keler", EmailAddress = "firatkeler@hotmail.com", AddressLine = "Kutahya", Country = "Turkey", TotalPrice = 350 }
            };
        }
	}
}

