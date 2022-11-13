namespace PaymentTracker.Models.Payments
{
    public class PaymentWithCustomerName
    {
        public long Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime EffectiveDate { get; set; }

        public string CustomerName { get; set; } = string.Empty;
    }
}
