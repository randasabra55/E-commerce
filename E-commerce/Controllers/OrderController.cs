using E_commerce.DTO;
using E_commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        Context context;
        public OrderController(Context context) 
        { 
            this.context = context;
        }
        ///////////////////////////////////////////////////////
        [HttpPost("CheckOut")]
        [Authorize]
        public IActionResult CheckOut()
        {
            if(ModelState.IsValid)
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
               // Card card=context.card.Include(c=>c.Items).
                //جبت الكارت بتاع اليوزر
                Card userCard = context.card.Include(c => c.Items).ThenInclude(ci=>ci.Product).FirstOrDefault(c => c.UserId == userId);
                //جبت البرودكت اللى جوا الكارت دى
                // CartItem cartItem = context.cartItems.FirstOrDefault(ci => ci.CardId == userCard.Id);
                //decimal totalPrice = 0;
                if (userCard != null)
                {
                    decimal totalPrice = userCard.Items.Sum(ci => ci.Quantity * ci.Product.Price);// cartItem.Product.Price * cartItem.Quantity;

                    //هعمل بقا الاوردر
                    Order order = new Order();
                    order.UserId = userId;
                    order.CreatedAt = DateTime.Now;
                    order.TotalPrice = totalPrice;
                    context.order.Add(order);
                    context.SaveChanges();
                    //هعمل الاورودر ديتيلز لكل بردكت
                    
                    foreach (var cardItem in userCard.Items)
                    {
                        OrderDetails orderDetails = new OrderDetails();
                        orderDetails.ProductId = cardItem.ProductId;
                        orderDetails.Quantity = cardItem.Quantity;
                        orderDetails.OrederId = order.Id;
                        orderDetails.PriceAtPurchase=cardItem.Product.Price;
                        context.orderDetails.Add(orderDetails);
                    }
                    context.SaveChanges();
                    context.cartItems.RemoveRange(userCard.Items);
                    context.SaveChanges();
                    return Ok(totalPrice);
                }
                else
                {
                    return BadRequest(new {message="cart has no products"});
                }

                /*OrderDetails orderDetails = new OrderDetails();
                orderDetails.Quantity = cartItem.Quantity;
                orderDetails.ProductId = cartItem.ProductId;
                //orderDetails.PriceAtPurchase=productsFromUser.
                orderDetails.PriceAtPurchase = cartItem.Product.Price;
               // decimal itemPrice = orderDetails.PriceAtPurchase * orderDetails.Quantity;
              //  decimal totalPrice = 0;
              //  totalPrice += itemPrice;
                context.card.Remove(userCard);
                context.SaveChanges();
                return Ok(totalPrice);*/
            }
            return BadRequest(ModelState);
        }
        ////////////////////////////////////////////////////////
        /*public IActionResult EditOrder()
        {
            return Ok();
        }*/
        ////////////////////////////////////////////////////////
        /*public IActionResult CancelOrder()
        {
            return Ok();
        }*/
        ////////////////////////////////////////////////////////
        /*public IActionResult ShowOerderDetails()
        {
            return Ok();
        }*/
    }
}
