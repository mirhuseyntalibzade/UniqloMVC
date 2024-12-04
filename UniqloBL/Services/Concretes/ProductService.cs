using Microsoft.EntityFrameworkCore;
using UniqloBL.Services.Abstractions;
using UniqloDAL.Contexts;
using UniqloDAL.Models;

namespace UniqloBL.Services.Concretes
{

    public class ProductService : IProductService
    {
        readonly UniqloDbContext _context;

        public ProductService(UniqloDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task EditProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            IEnumerable<Product> categories = await _context.Products.ToListAsync();
            return (categories);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            Product? product = await _context.Products.FirstOrDefaultAsync();
            return (product);
        }

    }
}
