﻿using Dapper;
using Microsoft.AspNetCore.Mvc;
using PaymentTracker.Models.Payments;
using System.Data.SqlClient;

namespace PaymentTracker.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;

        public PaymentsController(
            IConfiguration configuration
            )
        {
            this.connectionString = configuration.GetConnectionString("PaymentTracker");

            this.connection = new SqlConnection(connectionString);
        }

        public async Task<ActionResult> Create(Payment payment)
        {
            string query = "insert into Payments values(@Amount,@EffectiveDate,@CustomerId)";

            object queryParams = new
            {
                Amount = payment.Amount,
                EffectiveDate = payment.EffectiveDate,
                CustomerId = payment.CustomerId,
            };

            await connection.ExecuteAsync(query, queryParams);

            return RedirectToAction(controllerName: "Customers", actionName: "Details", routeValues: new
            {
                id = payment.CustomerId
            });
        }
    }
}
