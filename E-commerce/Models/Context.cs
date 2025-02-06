using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Models
{
    public class Context:IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> users {  get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<Card> card { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<Review> reviews { get; set; }

        public Context()
        {

        }
        public Context(DbContextOptions options):base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id=Guid.NewGuid().ToString(),
                    Name="Admin",
                    NormalizedName="admin",
                    ConcurrencyStamp= Guid.NewGuid().ToString()
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Customer",
                    NormalizedName = "customer",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
                );



            base.OnModelCreating(builder);
        }
    }
}
