using E_commerce.Models;

namespace E_commerce.DTO
{
    public class CategoryDTO
    {
        public string Name {  get; set; }
        public List<ProductDTO>? Products { get; set; }

    }
}
