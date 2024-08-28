using Product.DAL.Entities;
using ProductAPI.Implementations;
using ProductAPI.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Intefaces
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

        public async Task<ProductModel> GetProductByIDAsync(int productId)
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

        public async Task<bool> AddProductAsync(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProductAsync(ProductModel employee)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProductAsync(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
