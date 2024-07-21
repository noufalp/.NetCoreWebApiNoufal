using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using WebApp.Models;

namespace WebAppUnitTest
{
    public class ProductControllerTest
    {
        ProductController _controller;
        IRepository<Product> _repository;
        public ProductControllerTest()
        {
            _controller = new ProductController(_repository);
        }
        [Fact]
        public void GetAllProducts()
        {
            //Arrange

            //Act
            var result = _controller.Get();
            var resultType = result as IEnumerable<Product>;
            var resultList = resultType.ToList<Product>();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, resultList.Count);
        }
        [Fact]
        public void GetProductById()
        {
            //Arrange
            int validProductId = 1;
            int invalidEmployeeId = 10;

            //Act
            var errorResult = _controller.Get(invalidEmployeeId);
            var successResult = _controller.Get(validProductId);
            var successModel = successResult.Result;
            var fetchedProductId = successModel.Id;

            //Assert
            Assert.Equal(1, fetchedProductId);
        }
        [Fact]
        public void AddProduct()
        {
            //Arrange
            Product product = new Product()
            {
                Name = "Book",
                Price = 20,
                Description = "Two line note book"
            };

            //Act
            var response = _controller.Post(product);
            Assert.IsType<OkResult>(response);
            var createdProduct = response.Result;
            var productItem = createdProduct as Product;

            //Assert
            Assert.Equal("Book", productItem.Name);
            Assert.Equal(20, productItem.Price);
            Assert.Equal("Two line note book", productItem.Description);
        }
        [Fact]
        public void UpdateProduct()
        {
            //Arrange
            Product product = new Product()
            {
                Id = 1,
                Name = "Watch",
                Price = 3000,
                Description = "Fastrack"
            };

            //Act
            var response = _controller.Put(product);
            Assert.IsType<OkResult>(response);
            var createdProduct = response.Result;
            var productItem = createdProduct as Product;

            //Assert
            Assert.Equal("Watch", productItem.Name);
            Assert.Equal(3000, productItem.Price);
            Assert.Equal("Fastrack", productItem.Description);
        }
        [Fact]
        public void DeleteProduct() 
        {
            //Arrange
            int validProductId = 1;
            int invalidEmployeeId = 10;

            //Act
            var errorResult = _controller.Get(invalidEmployeeId);
            var successResult = _controller.Get(validProductId);

            //Assert
            Assert.IsType<OkResult>(successResult);
            Assert.IsType<NotFoundResult>(errorResult);
        }
    }
}
