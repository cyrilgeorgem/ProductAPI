using Product.DAL.Entities;
using ProductAPI.Models;

namespace ProductAPI.Implementations
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        Task<ProductModel> GetProductByIDAsync(int itemId);
        Task<bool> AddProductAsync(ProductModel employee);
        Task<bool> UpdateProductAsync(ProductModel employee);
        Task<bool> DeleteProductAsync(int productId);
    }
}
