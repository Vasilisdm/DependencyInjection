using DependencyInjection.Controllers;
using DependencyInjection.Infrastructure;
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

            TypeBroker.SetTestObject(mockRepository.Object);
            HomeController cntrl = new HomeController();

            // Act
            ViewResult result = cntrl.Index();

            // Assert
            Assert.Equal(data, result.ViewData.Model);
        } 
    }
}
