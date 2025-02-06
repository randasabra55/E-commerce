using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("Product")]
        public int ProductId {  get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("User")]
        public string UserId {  get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
