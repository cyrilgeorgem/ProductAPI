﻿using Product.DAL.Entities;
using ProductAPI.Interfaces;
using ProductAPI.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Implementations
{
    public class ProductRepository: IProductRepository
    {
        private AzureFDBContext _productDbContext;
        public ProductRepository(AzureFDBContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            try
            {
                IEnumerable<ProductModel> productList = await (from prod in _productDbContext.TblDpproducts
                                                               select new ProductModel
                                                               {
                                                                   ProductId = prod.ProductId,
                                                                   Name = prod.Name,
                                                                   Description = prod.Description,
                                                                   Price = prod.Price,
                                                                   CategoryId = prod.CategoryId,
                                                               }).ToListAsync();
                return productList;
            }
            catch (Exception ex)
            {
                return new List<ProductModel>();
            }
        }

        public async Task<ProductModel> GetProductByIDAsync(int productId)
        {
            try
            {
                ProductModel? prodObj = await (from prod in _productDbContext.TblDpproducts
                                               where prod.ProductId == productId
                                               select new ProductModel
                                               {
                                                   ProductId = prod.ProductId,
                                                   Name = prod.Name,
                                                   Description = prod.Description,
                                                   Price = prod.Price,
                                                   CategoryId = prod.CategoryId,
                                               }).FirstOrDefaultAsync();
                return prodObj;
            }
            catch (Exception ex)
            {
                return new ProductModel();
            }
        }

        public async Task<bool> AddProductAsync(ProductModel product)
        {
            try
            {
                TblDpproduct tblDpproduct = new TblDpproduct()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId
                };
                _productDbContext.TblDpproducts.Add(tblDpproduct);
                await _productDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProductAsync(ProductModel product)
        {
            try
            {
                TblDpproduct tblDpproduct = new TblDpproduct()
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId
                };
                _productDbContext.Entry(tblDpproduct).State = EntityState.Modified;
                await _productDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            try
            {
                TblDpproduct deleteProduct = await _productDbContext.TblDpproducts.FindAsync(productId);
                if (deleteProduct != null)
                {
                    _productDbContext.TblDpproducts.Remove(deleteProduct);
                    await _productDbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
