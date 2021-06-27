using Microsoft.EntityFrameworkCore;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Models
{
    public class ProductRepository :IProductRepository
    {
        private readonly AppDbContext appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Product> AddProduct(Product product)
        {
            var result = await appDbContext.Products.AddAsync(product);
            appDbContext.SaveChanges();
            return result.Entity;
        }

        public async Task<Product> DeleteProduct(int productid)
        {
            var result = await appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productid);

            if (result != null)
            {
                appDbContext.Remove(result);
                appDbContext.SaveChanges();
                return result;
            }

            return null;
        }

        public async Task<Product> GetProduct(int productid)
        {
            return await appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productid);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await appDbContext.Products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await appDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);

            if (result != null)
            {
                result.Name = product.Name;
                result.Description = product.Description;
                result.Price = product.Price;

                appDbContext.SaveChanges();

                return result;
            }

            return null;
        }
    }
}
