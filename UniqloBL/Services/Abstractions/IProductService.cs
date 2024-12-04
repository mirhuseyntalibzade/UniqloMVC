using UniqloDAL.Models;

namespace UniqloBL.Services.Abstractions
{
    public interface IProductService
    {
        public Task CreateProductAsync(Product product);
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task<Product> GetProductByIdAsync(int id);
        public Task EditProductAsync(Product product);
        public Task DeleteProductAsync(Product product);
    }
}
