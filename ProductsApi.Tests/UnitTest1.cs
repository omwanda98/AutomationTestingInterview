using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ProductsApi.Controllers;
using Xunit;
using Moq;

public class UnitTests
{
    [Fact]
    public void Get_ReturnsValidData()
    {
        // Arrange
        var controller = CreateWeatherForecastController();

        // Act
        var result = controller.Get();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Count());
    }

    [Fact]
    public void Get_ReturnsValidDataWithCorrectProperties()
    {
        // Arrange
        var controller = CreateWeatherForecastController();

        // Act
        var result = controller.Get();

        // Assert
        foreach (var forecast in result)
        {
            Assert.NotNull(forecast.Date);
            Assert.InRange(forecast.TemperatureC, -20, 55);
            Assert.Contains(forecast.Summary, ValidSummaries);
        }
    }

    // [Fact]
    // public void NonExistentEndpoint_ReturnsNotFound()
    // {
    //     // Arrange
    //     var controller = CreateWeatherForecastController();

    //     // Act
    //     var result = controller.GetNonExistentEndpoint();

    //     // Assert
    //     Assert.IsType<NotFoundResult>(result);
    // }

    private WeatherForecastController CreateWeatherForecastController()
    {
        var logger = new Mock<ILogger<WeatherForecastController>>();
        return new WeatherForecastController(logger.Object);
    }

    private static readonly string[] ValidSummaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
}
