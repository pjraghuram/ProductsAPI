using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsAPI.Repositories
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly ProductContext context;

        public SqlProductRepository(ProductContext context)
        {
            this.context = context;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            return await context.Products.ToListAsync();
        }
        public async Task<Product> GetProductAsync(Guid productId)
        {
            return await context.Products.FirstOrDefaultAsync(x => x.Id == productId);
        }

        public async Task<bool> Exists(Guid productId)
        {
            return await context.Products.AnyAsync(x => x.Id == productId);
        }

        public async Task<Product> UpdateProduct(Guid productId, Product request)
        {
            var existingProduct = await GetProductAsync(productId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = request.ProductName;
                existingProduct.Cost = request.Cost;
                existingProduct.Quantity = request.Quantity;
                existingProduct.CompanyName = request.CompanyName;

                await context.SaveChangesAsync();
                return existingProduct;
            }
            return null;
        }

        public async Task<Product> DeleteProduct(Guid productId)
        {
            var product = await GetProductAsync(productId);
            if (product != null)
            {
                context.Products.Remove(product);
                await context.SaveChangesAsync();
                return product;
            }
            return null;
        }

        public async Task<Product> AddProduct(Product request)
        {
            var product = await context.Products.AddAsync(request);
            await context.SaveChangesAsync();
            return product.Entity;
        }
    }
}
