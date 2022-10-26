using WebStore.UnitTests.Mocks;
using WebStore.Website.Controllers;
using WebStore.Website.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.UnitTests.Controllers
{
    public class PieControllerTests
    {
        [Fact]
        public void List_ShouldReturnAllPies_WhenCategoryParameterIsEmpty() 
        {
            // Arrange
            var pieRepositoryMock = RepositoryMocks.GetPieRepositoryMock();
            var categoryRepositoryMock = RepositoryMocks.GetPCatergoryRepositoryMock();

            var pieController = new PieController(pieRepositoryMock.Object, categoryRepositoryMock.Object);

            // Act
            var result = pieController.List("");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(10, pieListViewModel.Pies.Count());
        }

        [Theory]
        [InlineData("Fruit pies")]
        [InlineData("Cheese cakes")]
        [InlineData("Seasonal pies")]
        public void List_ShouldReturnPiesByCategory_WhenCategoryParameterIsNotEmpty(string category) 
        {
            // Arrange
            var pieRepositoryMock = RepositoryMocks.GetPieRepositoryMock();
            var categoryRepositoryMock = RepositoryMocks.GetPCatergoryRepositoryMock();

            var pieController = new PieController(pieRepositoryMock.Object, categoryRepositoryMock.Object);

            // Act
            var result = pieController.List(category);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
            Assert.True(pieListViewModel.Pies.All(p => p.Category.CategoryName == category));
        }
    }
}
