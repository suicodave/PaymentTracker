namespace PaymentTracker.Models.Payments
{
    public class Payment
    {
        public long Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime EffectiveDate { get; set; }

        public int CustomerId { get; set; }
    }
}
