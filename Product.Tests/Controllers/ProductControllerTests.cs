using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductAPI.Controllers;
using ProductAPI.Interfaces;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Tests.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly ProductController _productController;

        public ProductControllerTests()
        {
            //Setup mock repository
            _productRepositoryMock = new Mock<IProductRepository>();

            //Inject the mock repository into the controller
            _productController = new ProductController(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllProducts_ReturnsOkResult_WithProducts()
        {
            //Arrange
            var productList = new List<ProductModel>
            {
                new ProductModel {
                    ProductId = 1,
                    Name = "Product 1",
                    Description = "Prod 1 Desc",
                    Price = 50000,
                    CategoryId = 1
                },
                new ProductModel {
                    ProductId = 1,
                    Name = "Product 2",
                    Description = "Prod 2 Desc",
                    Price = 40000,
                    CategoryId = 1
                }
            };
            _productRepositoryMock.Setup(repo => repo.GetAllProductsAsync()).ReturnsAsync(productList);

            //Act
            var result = await _productController.GetAllProducts();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(productList, okResult.Value);
        }

        [Fact]
        public async Task GetAllProducts_ReurnsOkResult_WithEmptyList()
        {
            _productRepositoryMock.Setup(repo => repo.GetAllProductsAsync()).ReturnsAsync(new List<ProductModel>());

            var result = await _productController.GetAllProducts();

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(new List<ProductModel>(), okResult.Value);
        }

    }
}