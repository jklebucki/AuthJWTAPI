using AuthJWTAPI.Models.DTOs;

namespace AuthJWTAPI.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();
        ProductDTO GetProductById(int id);
        void AddProduct(ProductDTO productDto);
        void UpdateProduct(int id, ProductDTO productDto);
        void DeleteProduct(int id);
        IEnumerable<ProductDTO> SearchProductsByName(string name);
    }
}
