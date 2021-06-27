using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.API.Models;
using ShopBridge.Models;

namespace ShopBridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                return Ok(await productRepository.GetProducts());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from database");
            }
        }
        [HttpGet("{productid:int}")]
        public async Task<ActionResult<Product>> GetProduct(int productid)
        {
            try
            {
                var result = await productRepository.GetProduct(productid);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }

                product.ProductId = 0;
                var createdProduct = await productRepository.AddProduct(product);
                return CreatedAtAction(nameof(GetProduct), new { productid = createdProduct.ProductId }, createdProduct);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from database");
            }
        }

        [HttpDelete("{productid:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int productid)
        {
            try
            {                
                var result = await productRepository.GetProduct(productid);

                if (result == null)
                {
                    return NotFound();
                }

                var deletedResult = await productRepository.DeleteProduct(productid);
                return Ok(deletedResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from database");
            }
        }

        [HttpPut("{productid:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int productid, Product product)
        {
            try
            {
                if (productid != product.ProductId)
                {
                    return BadRequest();
                }

                var productToUpdate = await productRepository.GetProduct(productid);

                if (productToUpdate == null)
                {
                    return NotFound($"Product with Id {productid} not found");
                }

                 var updatedResult = await productRepository.UpdateProduct(product);
                return Ok(updatedResult);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from database");
            }
        }
    }
}
