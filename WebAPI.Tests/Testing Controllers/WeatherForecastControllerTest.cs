using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using UnitTesting.WebAPI;
using UnitTesting.WebAPI.Controllers;
using Xunit;

namespace WebAPI.Tests.Testing_Controllers
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void WeatherForecase_GetAction_ReturnsNotFoundWhenIdIsNull()
        {
            // Arrange
            string id = null;
            Mock<ILogger<WeatherForecastController>> loggerMock = new Mock<ILogger<WeatherForecastController>>();
            WeatherForecastController weatherForecastController = new WeatherForecastController(loggerMock.Object);

            // Act
            ActionResult<IEnumerable<WeatherForecast>> result = weatherForecastController.GetWeatherForecast(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        [Fact]
        public void WeatherForecase_GetAction_ReturnsData_WhenIdIsNotNull()
        {
            // Arrange
            string id = "2";
            Mock<ILogger<WeatherForecastController>> loggerMock = new Mock<ILogger<WeatherForecastController>>();
            WeatherForecastController weatherForecastController = new WeatherForecastController(loggerMock.Object);

            // Act
            ActionResult<IEnumerable<WeatherForecast>> result = weatherForecastController.GetWeatherForecast(id);

            // Assert
            var data = result.Value;
            Assert.IsType<ActionResult<IEnumerable<WeatherForecast>>>(result);
        }

        [Fact]
        public void WeatherForecase_GetAction_ReturnsData()
        {
            // Arrange
            string id = "2";
            Mock<ILogger<WeatherForecastController>> loggerMock = new Mock<ILogger<WeatherForecastController>>();
            WeatherForecastController weatherForecastController = new WeatherForecastController(loggerMock.Object);

            // Act
            ActionResult<IEnumerable<WeatherForecast>> result = weatherForecastController.GetWeatherForecast(id);

            // Assert
            var data = ((ObjectResult)result.Result).Value;
            Assert.NotNull(data);
        }


    }
}
