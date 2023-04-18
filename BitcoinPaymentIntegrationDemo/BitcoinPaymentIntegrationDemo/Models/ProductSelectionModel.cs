using System.ComponentModel.DataAnnotations;

namespace BitcoinPaymentIntegrationDemo.Models
{
    public class ProductSelectionModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
    }
}
