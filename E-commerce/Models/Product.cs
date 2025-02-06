using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity {  get; set; }
        public string ImageUrl {  get; set; }
        [ForeignKey("Category")]
        public int CategoryId {  get; set; }
        public Category? Category { get; set; }

        List<OrderDetails>? Details { get; set; }

        public virtual List<CartItem>? Items { get; set; }

        public virtual List<Review>? Reviews { get; set; }
    }
}
