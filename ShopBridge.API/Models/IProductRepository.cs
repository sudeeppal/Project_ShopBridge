using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.API.Models
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();

        public Task<Product> GetProduct(int productid);

        public Task<Product> AddProduct(Product product);

        public Task<Product> UpdateProduct(Product product);

        public Task<Product> DeleteProduct(int productid);
    }
}
