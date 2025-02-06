using E_commerce.DTO;
using E_commerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddingProductToCartController : ControllerBase
    {
        Context context;
        public AddingProductToCartController(Context context)
        {
            this.context = context;
        }
        //////////////////////////////////////////////////
        [HttpPost("AddProductToCart")]
        [Authorize]
        public IActionResult AddProductToCart(ProductsInCartDTO products)
        {
            if(ModelState.IsValid)
            {
                // string userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var UserCart = context.card.FirstOrDefault(c => c.UserId == userId);
                if (UserCart == null)
                {
                    //add cart for this user
                    Card card = new Card();
                    card.UserId = userId;
                    context.card.Add(card);
                    context.SaveChanges();
                }
                else
                {
                    //check if user have product that want to add again
                    CartItem productItem = context.cartItems.FirstOrDefault(ci => ci.CardId == UserCart.Id && ci.ProductId == products.ProductId);
                    //if exist
                    if (productItem != null)
                    {
                        productItem.Quantity += products.ProductQuantity;
                        context.SaveChanges();
                    }
                    else
                    {
                        CartItem cartItem = new CartItem();
                        cartItem.CardId = UserCart.Id;
                        cartItem.Quantity = products.ProductQuantity;
                        cartItem.ProductId = products.ProductId;
                        context.cartItems.Add(cartItem);
                        context.SaveChanges();
                    }

                }
                return Ok(new { message = "the product has successfully added to cart" });
            }
           return BadRequest(ModelState);
        }

        //////////////////////////////////////////////////
        [HttpPut("EditProductInCart/{productId:int}")]
        [Authorize]
        public IActionResult EditProductInCart(int productId, ProductsInCartDTO prouctFromUser)
        {
            if (ModelState.IsValid)
            {
                CartItem product = context.cartItems.FirstOrDefault(c => c.ProductId == productId);
                if (product != null)
                {
                    product.ProductId = prouctFromUser.ProductId;
                    product.Quantity=prouctFromUser.ProductQuantity;
                    context.cartItems.Update(product);
                    context.SaveChanges();
                    return Ok(new { message = $"product updated successfully" });
                }
                return NotFound(new { message = "product not found" });
            }
            return BadRequest(ModelState);
        }

        /////////////////////////////////////////////////
        [HttpDelete("DeleteProductFromCart/{productId:int}")]
        [Authorize]
        public IActionResult DeleteProductFromCart(int productId)
        {
            if (ModelState.IsValid)
            {
                CartItem product = context.cartItems.FirstOrDefault(c => c.ProductId == productId);
                if (product != null)
                {
                    context.cartItems.Remove(product);
                    context.SaveChanges();
                    return Ok(new { message = "product deleted successfully" });
                }
                return NotFound(new { message = "product not found" });
            }
            return BadRequest(ModelState);
        }

        /////////////////////////////////////////////////
        [HttpGet("ShowAllProductsInCart")]
        [Authorize]
        public IActionResult ShowCartForUser()
        {
            string userId=User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Card userCard=context.card.FirstOrDefault(c => c.UserId == userId);
            if (userCard != null)
            {
                
                List<CartItem> cartItems=context.cartItems.Include(ci=>ci.Product).ToList();
                List<ShowProductsInCardDTO> show=new List<ShowProductsInCardDTO>();
                foreach (CartItem cartItem in cartItems)
                {
                    ShowProductsInCardDTO showItem=new ShowProductsInCardDTO();
                    showItem.ProductName=cartItem.Product.Name;
                    showItem.Quantity=cartItem.Quantity;
                    show.Add(showItem);
                }
                return Ok(show);
            }
            else
            {
                return Ok(new {message="Cart has no products"});
            }
            
            // List<CartItem> products = context.product.Items;
            return Ok();
        }
    }
}
