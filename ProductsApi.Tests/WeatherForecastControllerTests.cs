using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ProductsApi.Controllers;
using Xunit;
using Moq;

public class WeatherForecastControllerTests
{
    [Fact]

    //1. check if valid results are returned
    public void Get_ReturnsValidData() //check if valid results are returned
    {
        // Arrange
        var controller = CreateWeatherForecastController();

        // Act
        var result = controller.Get();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(5, result.Count()); 
    }

    [Fact]//2. validity of properties date..
    public void Get_ReturnsValidDataWithCorrectProperties() //validity of properties date..
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
            Assert.Contains(forecast.Summary, Summaries);
        }
    }

    //creating instance of the controller
    private WeatherForecastController CreateWeatherForecastController()//creating instance of the controller
    {
        var logger = new Mock<ILogger<WeatherForecastController>>(); //mock logger
        return new WeatherForecastController(logger.Object);
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
}
