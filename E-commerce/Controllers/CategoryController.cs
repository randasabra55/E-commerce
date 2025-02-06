using E_commerce.DTO;
using E_commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Context context;
        public CategoryController(Context context)
        {
            this.context = context;
        }
        [HttpPost("AddCategory")]
        [Authorize(Roles ="Admin")]
        public IActionResult AddCategory(CategoryDTO categoryFromAdmin)
        {
            if(ModelState.IsValid)
            {
                Category category = new Category();
                category.Name = categoryFromAdmin.Name;
                context.category.Add(category);
                context.SaveChanges();
                return Ok($"Category {category.Name} added successfully");
            }
            return BadRequest(ModelState);
        }
        ///////////////////////////////////////////////////////
         [HttpPut("EditCategory/{id:int}")]
       // [HttpPut("EditCategory")]
       // [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult EditCategory(int id,CategoryDTO categoryFromAdmin)
        {
            if (ModelState.IsValid)
            {
                Category category = context.category.FirstOrDefault(c=>c.Id==id);
                if (category == null)
                {
                    return NotFound("category not fount");
                }
                category.Name = categoryFromAdmin.Name;
                context.category.Update(category);
                context.SaveChanges();
                return Ok($"Category {category.Name} updated successfully");
            }
            return BadRequest(ModelState);
        }
        //////////////////////////////////////////////////////
        [HttpDelete("DeleteCategory/{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(int id)
        {
            Category category=context.category.FirstOrDefault(c=>c.Id == id);
            context.category.Remove(category);
            context.SaveChanges();
            return Ok($"Category deleted successfully");
        }

        ////////////////////////////////////////////////
        [HttpGet("ShowAllCategories")]
        [Authorize]
        public IActionResult ShowAllCategories()
        {
            List<Category> categories = context.category.Include(c=>c.Products).ToList();
            List<CategoryDTO> categoriesDtoList = new List<CategoryDTO>();
            foreach (Category category in categories)
            {
                CategoryDTO categoryDto = new CategoryDTO();
                categoryDto.Name = category.Name;
                categoryDto.Products = new List<ProductDTO>();
                foreach (var product in category.Products)
                {
                    ProductDTO productDto = new ProductDTO();
                    productDto.Name = product.Name;
                    productDto.ImageUrl = product.ImageUrl;
                    productDto.Description = product.Description;
                    productDto.Price = product.Price;
                    productDto.StockQuantity = product.StockQuantity;
                    productDto.CategoryId = category.Id;
                    categoryDto.Products.Add(productDto);
                }

                categoriesDtoList.Add(categoryDto);
            }
            return Ok(categoriesDtoList);
        }
        ///////////////////////////////////////////////
        [HttpGet("CategoryDetails/{id:int}")]
        [Authorize]
        public IActionResult CategoryDetails(int id)
        {
            Category category=context.category.Include(c=>c.Products).FirstOrDefault(c=>c.Id==id);

            if(category == null)
            {
                return NotFound("Category not found");
            }
            CategoryDTO categoryDTO = new CategoryDTO();
            
            categoryDTO.Name = category.Name;
            categoryDTO.Products = new List<ProductDTO>();
            foreach (var product in category.Products)
            {
                ProductDTO productDto = new ProductDTO();
                productDto.Name = product.Name;
                productDto.ImageUrl = product.ImageUrl;
                productDto.Description = product.Description;
                productDto.Price = product.Price;
                productDto.StockQuantity= product.StockQuantity;
                productDto.CategoryId = category.Id;
                categoryDTO.Products.Add(productDto);
            }
            return Ok(categoryDTO);
        }
        ////////////////////////////////////////////////
        [HttpGet("CategoryDetailsByName/{name:alpha}")]
        [Authorize]
        public IActionResult CategoryDetailsByName(string name)
        {
            Category category = context.category.Include(c => c.Products).FirstOrDefault(c => c.Name == name);

            if (category == null)
            {
                return NotFound("Category not found");
            }
            CategoryDTO categoryDTO = new CategoryDTO();

            categoryDTO.Name = category.Name;
            categoryDTO.Products = new List<ProductDTO>();
            foreach (var product in category.Products)
            {
                ProductDTO productDto = new ProductDTO();
                productDto.Name = product.Name;
                productDto.ImageUrl = product.ImageUrl;
                productDto.Description = product.Description;
                productDto.Price = product.Price;
                productDto.StockQuantity = product.StockQuantity;
                productDto.CategoryId = category.Id;
                categoryDTO.Products.Add(productDto);
            }
            return Ok(categoryDTO);
        }
    }
}
