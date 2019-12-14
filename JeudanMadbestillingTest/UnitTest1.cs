using System;
using System.Collections.Generic;
using System.Linq;
using JeudanMadbestilling;
using JeudanMadbestilling.Models;
using JeudanMadbestilling.Data;
using JeudanMadbestilling.Controllers;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace JeudanMadbestillingTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddMethodWithTwoPositiveNumbers()
        {
            //Arrange - instan. classes etc.
            var testService = new TestService();

            //Act - Call the method to test
            int result = testService.Add(2, 5);

            //Assert - Check if you get the right result back
            Assert.Equal(7, result);
        }

        [Fact]
        public void TestIndexMethodReturnsObjects()
        {
            // Arrange
            var mockRepo = new Mock<IMadmenuRepository>();
            var mockMenuRepo = new Mock<IMadbestillingRepository>();
            mockRepo.Setup(repo => repo.Get())
                .Returns(DataTestService.GetTestMadmenu());
            var controller = new MadMenuController(mockMenuRepo.Object, mockRepo.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<MadMenu>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void CreatePost_ReturnsViewWithSpecies_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<IMadmenuRepository>();
            var mockMenuRepo = new Mock<IMadbestillingRepository>();
            var controller = new MadMenuController(mockMenuRepo.Object, mockRepo.Object);

            controller.ModelState.AddModelError("Name", "Required");
            var madmenu = new MadMenu() { MenuId = 1, Menu = "Karl Karlson something nice" };

            // Act
            var result = controller.Create(madmenu);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<MadMenu>(viewResult.ViewData.Model);
            Assert.IsType<MadMenu>(model);
        }

        [Fact]
        public void CreatePost_SaveThroughRepository_WhenModelStateIsValid()
        {
            // Arrange
            var mockRepo = new Mock<IMadmenuRepository>();
            var mockMenuRepo = new Mock<IMadbestillingRepository>();
            mockRepo.Setup(repo => repo.Save(It.IsAny<MadMenu>()))
                //.Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new MadMenuController(mockMenuRepo.Object, mockRepo.Object);
            MadMenu s = new MadMenu()
            {
                MenuId = 1,
                Menu = "Don't listen to scientists"
            };

            // Act
            var result = controller.Create(s);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();
        }

        [Fact]
        public void TestDeleteWorks_In_Controller()
        {
            //Arrange
            var menuId = 1;
            var mockRepo = new Mock<IMadmenuRepository>();
            var mockMenuRepo = new Mock<IMadbestillingRepository>();
            mockRepo.Setup(repo => repo.Delete(menuId)).Verifiable();
            var controller = new MadMenuController(mockMenuRepo.Object, mockRepo.Object);

            //Act
            var result = controller.Delete(menuId);

            //Assert
            Assert.IsType<ViewResult>(result);
            mockRepo.Verify();

        }
    }
} 