using Dapper;
using Microsoft.AspNetCore.Mvc;
using PaymentTracker.Models.Customers;
using PaymentTracker.Models.Payments;
using System.Data.SqlClient;

namespace PaymentTracker.Controllers
{
    public class CustomersController : Controller
    {
        private readonly string connectionString;
        private readonly SqlConnection connection;

        public CustomersController(
            IConfiguration configuration
            )
        {
            this.connectionString = configuration.GetConnectionString("PaymentTracker");

            this.connection = new SqlConnection(connectionString);
        }

        // GET: CustomerController
        public async Task<ActionResult> Index()
        {
            string query = "select * from customers order by FirstName,LastName";

            IEnumerable<Customer> customers = await connection.QueryAsync<Customer>(query) ?? Enumerable.Empty<Customer>();

            ViewData["customers"] = customers;

            return View();
        }

        // GET: CustomerController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            string customerQuery = "select top 1 * from Customers where Id = @Id";

            object queryParameter = new
            {
                Id = id
            };

            Customer customer = await connection.QueryFirstAsync<Customer>(customerQuery, queryParameter);

            string paymentsQuery = "select * from Payments where CustomerId = @CustomerId order by Id desc";

            object paymentsQueryParamter = new
            {
                CustomerId = id
            };

            IEnumerable<Payment> payments = await connection.QueryAsync<Payment>(paymentsQuery, paymentsQueryParamter) ?? Enumerable.Empty<Payment>();

            ViewData["Customer"] = customer;

            ViewData["Payments"] = payments;

            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
