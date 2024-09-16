using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Product.DAL.Entities;
using ProductAPI.Implementations;
using ProductAPI.Interfaces;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Tests.Repositories
{
    public class ProductRepositoryTests
    {
        private readonly AzureFDBContext _productDbContext;
        private readonly IProductRepository _productRepository;
        public ProductRepositoryTests()
        {
            //Setup InMemory Database for testing
            var options = new DbContextOptionsBuilder<AzureFDBContext>()
                .UseInMemoryDatabase(databaseName: "ProductTestDB").Options;

            _productDbContext = new AzureFDBContext(options);
            _productRepository = new ProductRepository(_productDbContext);

            //Seed the in-memory database
            SeedTestDB();
        }

        private void SeedTestDB()
        {
            _productDbContext.TblDpproducts.AddRange(
                new TblDpproduct { ProductId = 1, Name = "Product 1", Description = "Product Desc 1", Price = 40000, CategoryId = 1 },
                new TblDpproduct { ProductId = 2, Name = "Product 2", Description = "Product Desc 2", Price = 50000, CategoryId = 1 }
            );
            _productDbContext.SaveChanges();
        }

        [Fact]
        public async Task GetAllProducts_ReturnsAllEmployees()
        {
            // Act
            var result = await _productRepository.GetAllProductsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

    }
}
