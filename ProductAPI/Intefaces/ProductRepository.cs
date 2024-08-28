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
            IEnumerable<ProductModel> productList = await (from item in _productDbContext.TblDpproducts
                                                     select new ProductModel
                                                     {
                                                         ItemId = item.ProductId,
                                                         Name = item.Name,
                                                         Description = item.Description,
                                                         Price = item.Price,
                                                         CategoryId = item.CategoryId,
                                                     }).ToListAsync();
            return productList;
        }

        public async Task<ProductModel> GetProductByIDAsync(int itemId)
        {
            ProductModel? itemObj = await (from item in _productDbContext.TblBcitems
                                        where item.ItemId == itemId
                                        select new ProductModel
                                        {
                                            ItemId = item.ItemId,
                                            Name = item.Name,
                                            Description = item.Description,
                                            Price = item.Price,
                                            CategoryId = item.CategoryId,
                                        }).FirstOrDefaultAsync();
            return itemObj;
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
