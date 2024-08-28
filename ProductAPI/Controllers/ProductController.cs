using Microsoft.AspNetCore.Mvc;
using Product.DAL.Entities;
using ProductAPI.Intefaces;
using ProductAPI.Implementations;
using ProductAPI.Models;
using Microsoft.AspNetCore.Http;

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
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                IEnumerable<ProductModel> prodList = await _productRepository.GetAllProductsAsync();
                return Ok(prodList);
            }
            catch (Exception ex)
            {
                return BadRequest("Error fetching Products");
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
                return BadRequest("Error fetching Product");
            }
        }

        // POST api/Product/AddNewProduct
        [HttpPost("AddNewProduct")]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductModel product)
        {
            try
            {
                bool status = await _productRepository.AddProductAsync(product);
                if (status == true)
                {
                    return Ok(StatusCodes.Status201Created);
                }
                else
                {
                    return BadRequest("Error adding product");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
