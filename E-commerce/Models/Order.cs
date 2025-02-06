using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal TotalPrice {  get; set; }
        [ForeignKey("User")]
        public string UserId {  get; set; }
        public ApplicationUser User { get; set; }
        List<OrderDetails>? Details { get; set; }
    }
}
