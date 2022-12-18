
using System.ComponentModel.DataAnnotations;

namespace PaymentTracker.Models.Customers
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; } = DateTime.Now;

        public decimal TotalPayments { get; set; }
    }
}
