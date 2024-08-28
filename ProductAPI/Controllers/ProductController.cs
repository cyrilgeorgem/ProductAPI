using Microsoft.AspNetCore.Mvc;
using Product.DAL.Entities;
using ProductAPI.Intefaces;
using ProductAPI.Implementations;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Product/GetAllProducts
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetItemList()
        {
            try
            {
                IEnumerable<ProductModel> prodList = await _productRepository.GetAllProductsAsync();
                return Ok(prodList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/Product/1
        [HttpGet("GetProductById/{productId:int}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            try
            {
                ProductModel prodObj = new ProductModel();
                prodObj = await _productRepository.GetProductByIDAsync(productId);
                return Ok(prodObj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
