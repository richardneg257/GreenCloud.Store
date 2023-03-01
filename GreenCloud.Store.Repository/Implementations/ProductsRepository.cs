using GreenCloud.Store.Entity;
using GreenCloud.Store.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GreenCloud.Store.Repository.Implementations
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly StoreContext context;

        public ProductsRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetProduct(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async Task InsertProduct(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}
