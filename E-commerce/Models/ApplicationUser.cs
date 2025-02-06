using Microsoft.AspNetCore.Identity;

namespace E_commerce.Models
{
    public class ApplicationUser:IdentityUser
    {
        public Card? Card { get; set; }
        public virtual List<Order>? Order { get; set; }
        public virtual List<Review>? Reviews { get; set; }
    }
}
