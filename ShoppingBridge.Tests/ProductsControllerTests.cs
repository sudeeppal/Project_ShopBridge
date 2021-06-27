using Microsoft.AspNetCore.Mvc;
using Moq;
using ShopBridge.API.Controllers;
using ShopBridge.API.Models;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace ShoppingBridge.Tests
{
    public class ProductsControllerTests
    {
        List<Product> products = new List<Product>(){
            new Product()
            {
                ProductId = 1,
                Name = "OnePlus CE 5G",
                Description = "OnePlus CE 5G Mobile",
                Price = 27999.00M
            },
                  new Product()
                  {
                      ProductId = 2,
                      Name = "Moto G 5G",
                      Description = "Moto G 5G Mobile",
                      Price = 21999.00M
                  },
                  new Product()
                  {
                      ProductId = 3,
                      Name = "Samsung M42 5G",
                      Description = "Samsung M42 5G Mobile",
                      Price = 22999.00M
                  }
            };

        public Mock<IProductRepository> repository = new Mock<IProductRepository>();

       [Fact]
        public void GetProducts_ReturnsOk()
        {
            //Arrange
            repository.Setup(r => r.GetProducts()).ReturnsAsync(products);
            var controller = new ProductsController(repository.Object);

            //Act
            var okResult = controller.GetProducts();

            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);

        }

        [Fact]
        public void GetProduct_ReturnsOk()
        {
            //Arrange
            repository.Setup(r => r.GetProduct(It.IsAny<int>()))
                .ReturnsAsync((int i) => products.Where(x => x.ProductId == i).Single());
            var controller = new ProductsController(repository.Object);

            //Act
            var okResult = controller.GetProduct(1);
            var result = okResult.Result as ActionResult<Product>;

            //Assert
            Assert.IsType<OkObjectResult>(result.Result as OkObjectResult);

        }       

        [Fact]
        public void AddProduct_ReturnsOk()
        {
            Product product = new Product()
            {
                ProductId = 4,
                Name = "Nokia 8.1",
                Description = "Nokia 8.1 Mobile",
                Price = 21999.00M
            };

            //Arrange
            repository.Setup(x => x.AddProduct(product)).ReturnsAsync(product);

            var controller = new ProductsController(repository.Object);

            //Act
            var createdResult = controller.AddProduct(product);
            var result = createdResult.Result as ActionResult<Product>;

            //Assert
            Assert.IsType<CreatedAtActionResult>(result.Result as CreatedAtActionResult);
        }

        [Fact]
        public void DeleteProduct_ReturnsOk()
        {
            //Arrange
            repository.Setup(r => r.GetProduct(It.IsAny<int>()))
                .ReturnsAsync((int i) => products.Where(x => x.ProductId == i).Single());
            var controller = new ProductsController(repository.Object);

            //Act
            var deletedResult = controller.DeleteProduct(3);
            var result = deletedResult.Result as ActionResult<Product>;

            //Assert
            Assert.IsType<OkObjectResult>(result.Result as OkObjectResult);
;
        }

        [Fact]
        public void UpdateProduct_ReturnsOk()
        {
            Product product = new Product()
            {
                ProductId = 1,
                Name = "OnePlus New CE 5G",
                Description = "OnePlus New CE 5G Mobile",
                Price = 27999.00M
            };

            //Arrange
            repository.Setup(r => r.GetProduct(It.IsAny<int>()))
                .ReturnsAsync((int i) => products.Where(x => x.ProductId == i).Single());

            var controller = new ProductsController(repository.Object);

            //Act
            var updatedResult = controller.UpdateProduct(1, product);
            var result = updatedResult.Result as ActionResult<Product>;

            //Assert
            Assert.IsType<OkObjectResult>(result.Result as OkObjectResult);

        }

    }
}
