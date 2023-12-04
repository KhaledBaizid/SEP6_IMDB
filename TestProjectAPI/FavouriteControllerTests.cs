using Backend.Controllers;
using Backend.DataAccessObjects.Favourite;
using Shared;

namespace TestProjectAPI;

// Install the necessary NuGet packages:
// NUnit
// Moq
// Microsoft.AspNetCore.Mvc.Core (for ControllerBase)

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

[TestFixture]
public class FavouriteControllerTests
{
   
    [Test]
    public async Task GetTheFavouriteListOfMoviesByUserID_ValidRequest_ReturnsListOfMovies()
    {
        // Arrange
        var favouriteInterfaceMock = new Mock<IFavouriteInterface>();
        var favouriteController = new FavouriteController(favouriteInterfaceMock.Object);
        var userId = 123;
        Favourite favourite1 = new Favourite { UserId = 123,MovieId = 123456};
        Favourite favourite2 = new Favourite { UserId = 123,MovieId = 456789};
        var expectedMovies = new List<Favourite> {favourite1,favourite2 };
        
        favouriteInterfaceMock
            .Setup(x => x.GetListOfFavouriteMovies(userId))
            .ReturnsAsync(expectedMovies);

        // Act
        var result = await favouriteController.GetTheFavouriteListOfMoviesByUserID(userId);

        // Assert
        Assert.IsInstanceOf<ActionResult<List<Favourite>>>(result);
        var objectResult = (ObjectResult)result.Result;
        Assert.AreEqual(200, objectResult.StatusCode);
        Assert.AreEqual(expectedMovies, objectResult.Value);

        // Verify that the GetListOfFavouriteMovies method was called with the correct parameter
        favouriteInterfaceMock.Verify(x => x.GetListOfFavouriteMovies(userId), Times.Once);
    }

    [Test]
    public async Task GetTheFavouriteListOfMoviesByUserID_ExceptionThrown_ReturnsInternalServerError()
    {
        // Arrange
        var favouriteInterfaceMock = new Mock<IFavouriteInterface>();
        var favouriteController = new FavouriteController(favouriteInterfaceMock.Object);
        var userId = 123;

        favouriteInterfaceMock
            .Setup(x => x.GetListOfFavouriteMovies(userId))
            .ThrowsAsync(new Exception("Some error message"));

        // Act
        var result = await favouriteController.GetTheFavouriteListOfMoviesByUserID(userId);

        // Assert
        Assert.IsInstanceOf<ActionResult<List<Favourite>>>(result);
        var objectResult = (ObjectResult)result.Result;
        Assert.AreEqual(500, objectResult.StatusCode);
        Assert.AreEqual("Some error message", objectResult.Value);
    }
    
    [Test]
    public async Task DeleteMovieToFavourite_Success_ReturnsOkResult()
    {
        // Arrange
        var mockFavouriteService = new Mock<IFavouriteInterface>();
        mockFavouriteService
            .Setup(service => service.DeleteFavouriteMovieAsync(It.IsAny<int>(), It.IsAny<long>()))
            .Verifiable();

        var controller = new FavouriteController(mockFavouriteService.Object);

        // Act
        var result = await controller.DeleteMovieToFavourite(1, 123);

        // Assert
      //  var objectResult = (ObjectResult)result;
      //  Assert.AreEqual(200, objectResult.StatusCode);
        mockFavouriteService.Verify(service => service.DeleteFavouriteMovieAsync(1, 123), Times.Exactly(1));
    }

    [Test]
    public async Task DeleteMovieToFavourite_Exception_ReturnsInternalServerError()
    {
        // Arrange
        var mockFavouriteService = new Mock<IFavouriteInterface>();
        mockFavouriteService
            .Setup(service => service.DeleteFavouriteMovieAsync(It.IsAny<int>(), It.IsAny<long>()))
            .ThrowsAsync(new Exception("Some error"));

        var controller = new FavouriteController(mockFavouriteService.Object);

        // Act
        var result = await controller.DeleteMovieToFavourite(1, 123);

        // Assert
        var objectResult = (ObjectResult)result;
        Assert.AreEqual(500, objectResult.StatusCode);
      //  var objectResult = result as ObjectResult;
      Assert.AreEqual(500, objectResult.StatusCode);
       
        mockFavouriteService.Verify(service => service.DeleteFavouriteMovieAsync(1, 123), Times.Once);
    }
}
