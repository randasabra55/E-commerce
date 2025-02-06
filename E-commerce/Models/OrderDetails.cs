using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int Quantity {  get; set; }
        public decimal PriceAtPurchase { get; set; }

        public Product Product { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Order Order { get; set; }
        [ForeignKey("Order")]
        public int OrederId {  get; set; }

    }
}
