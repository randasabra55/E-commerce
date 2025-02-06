using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Card
    {
        public int Id { get; set; }
       // public int Quantity {  get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public virtual List<CartItem>? Items { get; set; }
    }
}
