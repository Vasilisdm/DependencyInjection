using DependencyInjection.Controllers;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DependencyInjection.Tests
{
    public class DITests
    {
        [Fact]
        public void ControllerTest()
        {
            // Arrange
            var data = new[] { new Product { Name = "Test", Price = 100 } };
            var mockRepository = new Mock<IRepository>();
            mockRepository.SetupGet(m => m.Products).Returns(data);

            HomeController controller = new HomeController
            {
                Repository = mockRepository.Object
            };

            // Act
            ViewResult result = controller.Index();

            // Assert
            Assert.Equal(data, result.ViewData.Model);
        } 
    }
}
