using AuthJWTAPI.Models;

namespace AuthJWTAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 10.00m, Stock = 100, Category = "Category 1", Manufacturer = "Manufacturer 1", CreatedAt = DateTime.UtcNow, IsActive = true },
                new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 20.00m, Stock = 50, Category = "Category 2", Manufacturer = "Manufacturer 2", CreatedAt = DateTime.UtcNow, IsActive = true },
                new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 30.00m, Stock = 200, Category = "Category 3", Manufacturer = "Manufacturer 3", CreatedAt = DateTime.UtcNow, IsActive = true }
            };
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id)!;
        }

        public void Add(Product product)
        {
            var newId = _products.Max(p => p.Id) + 1;
            product.Id = newId;
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = GetById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
                existingProduct.Category = product.Category;
                existingProduct.Manufacturer = product.Manufacturer;
                existingProduct.IsActive = product.IsActive;
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}
