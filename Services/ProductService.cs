using AuthJWTAPI.Models;
using AuthJWTAPI.Models.DTOs;
using AuthJWTAPI.Repositories;
using AutoMapper;

namespace AuthJWTAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public ProductDTO GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public void AddProduct(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _productRepository.Add(product);
        }

        public void UpdateProduct(int id, ProductDTO productDto)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            var updatedProduct = _mapper.Map(productDto, existingProduct);
            _productRepository.Update(updatedProduct);
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            _productRepository.Delete(id);
        }

        public IEnumerable<ProductDTO> SearchProductsByName(string name)
        {
            var products = _productRepository.GetAll()
                                             .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}
