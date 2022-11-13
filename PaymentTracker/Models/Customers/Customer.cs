namespace PaymentTracker.Models.Customers
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime Birthdate { get; set; }

        public decimal TotalPayments { get; set; }
    }
}
