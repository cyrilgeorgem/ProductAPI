using Product.DAL.Entities;
using ProductAPI.Models;

namespace ProductAPI.Implementations
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetProductByIDAsync(int productId);
        Task<bool> AddProductAsync(ProductModel product);
        Task<bool> UpdateProductAsync(ProductModel product);
        Task<bool> DeleteProductAsync(int productId);
    }
}
