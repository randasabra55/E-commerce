using E_commerce.DTO;
using E_commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        Context context;
        public ProductController(Context context)
        {
            this.context = context;
        }
        /////////////////////////////////
        [HttpPost("AddProduct")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct(ProductDTO productFromAdmin)
        {
            if (ModelState.IsValid)
            {
                //mapping
                Product product = new Product();
                product.Name = productFromAdmin.Name;
                product.Description = productFromAdmin.Description;
                product.Price = productFromAdmin.Price;
                product.StockQuantity = productFromAdmin.StockQuantity;
                product.CategoryId = productFromAdmin.CategoryId;
                product.ImageUrl = productFromAdmin.ImageUrl;
                context.product.Add(product);
                context.SaveChanges();
                return Ok($"product {product.Name} added successfully");
            }
            return BadRequest(ModelState);
        }
        ////////////////////////////////////////////
        [HttpPut("EditProduct/{id:int}")]//الاى دى دا اللى هيتبعت
        [Authorize(Roles = "Admin")]
        public IActionResult EditProduct(int id, ProductDTO productFromAdmin)//الاى دى دا هو اللى هستقبله من اليوزر اللى هيبعته
        {
            if (ModelState.IsValid)
            {
                Product product = context.product.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    product.Name = productFromAdmin.Name;
                    product.Description = productFromAdmin.Description;
                    product.Price = productFromAdmin.Price;
                    product.StockQuantity = productFromAdmin.StockQuantity;
                    product.CategoryId = productFromAdmin.CategoryId;
                    product.ImageUrl = productFromAdmin.ImageUrl;
                    context.Update(product);
                    context.SaveChanges();
                    return Ok($"Product {product.Name} updated successfully");
                }
                else
                {
                    return BadRequest("Product not found");
                }
            }
            return BadRequest(ModelState);

        }
        ////////////////////////////////////////////
        [HttpDelete("{id:int}/DeleteProduct")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(int id)
        {
            if(ModelState.IsValid)
            {
                Product product = context.product.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    context.product.Remove(product);
                    context.SaveChanges();
                    return Ok("Product deleted successfully");
                }
                return NotFound("Product not found");
            }
            return BadRequest(ModelState);
        }
        //////////////////////////////////////////////

        [HttpGet("GetProductById/{id}")]
        [Authorize]
        public IActionResult GetProductDetails(int id)
        {
            if(ModelState.IsValid)
            {
                Product product = context.product.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    return Ok(product);
                }
                return NotFound("Product not found");
            }
            return BadRequest(ModelState);
        }
        ///////////////////////////////////////////////

        [HttpGet("GetProductByName/{name:alpha}")]
        [Authorize]
        public IActionResult GetProductDetailsByName(string name)
        {
            if (ModelState.IsValid)
            {
                Product product = context.product.FirstOrDefault(p => p.Name == name);
                if (product != null)
                {
                    return Ok(product);
                }
                return NotFound("Product not found");
            }
            return BadRequest(ModelState);
        }

        ///////////////////////////////////////////////
        [HttpGet("ShowAllProducts")]
        [Authorize]
        public IActionResult ShowAllProducts()
        {
            List<Product> products = context.product.ToList();
            return Ok(products);
        }
    }
}
