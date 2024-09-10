using AuthJWTAPI.Models.DTOs;
using AuthJWTAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AuthJWTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult AddProduct(ProductDTO productDto)
        {
            _productService.AddProduct(productDto);
            return Ok();
        }

        // PUT: api/Product/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductDTO productDto)
        {
            try
            {
                _productService.UpdateProduct(id, productDto);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: api/Product/search?name=example
        [HttpGet("search")]
        public ActionResult<IEnumerable<ProductDTO>> SearchProductsByName([FromQuery] string name)
        {
            var products = _productService.SearchProductsByName(name);
            return Ok(products);
        }
    }
}
