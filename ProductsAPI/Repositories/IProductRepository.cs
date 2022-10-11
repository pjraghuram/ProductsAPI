using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsAPI.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(Guid productId);
        Task<bool> Exists(Guid productId);
        Task<Product> UpdateProduct(Guid productId, Product request);
        Task<Product> DeleteProduct(Guid productId);
        Task<Product> AddProduct(Product request);
    }
}
