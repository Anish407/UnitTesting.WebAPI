using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using UnitTesting.WebAPI.Controllers;
using UnitTesting.WebAPI.Model;

namespace WebAPI.Tests.Testing_HttpContext
{
    public class HttpContextTests
    {
        // Testing HttpContext inside a controller
        [Fact]
        public void MockingHttpContext_GetData_ReturnsIpAndPath()
        {
            // Arrange
            var remoteIpAddress = IPAddress.Parse("222.222.222.222");
            string path = "/home/demo";

            Mock<ILogger<WeatherForecastController>> loggerMock = new Mock<ILogger<WeatherForecastController>>();

            var featureCollectionsMock = new Mock<IFeatureCollection>();
            featureCollectionsMock.Setup(x => x.Get<IHttpConnectionFeature>()).Returns(new HttpConnectionFeature
            {
                RemoteIpAddress = remoteIpAddress,
            });

            // option 1: either create an object or mock

            //HttpContext context = new DefaultHttpContext();
            //context.Request.Path = "";
            //context.Request.Headers["Authorization"] = "demo token"; .Connection.RemoteIpAddress;


            // option 2: Mock HttpContext
            Mock<HttpContext> httpContext = new Mock<HttpContext>();
            httpContext.Setup(context=> context.Features).Returns(featureCollectionsMock.Object);
            httpContext.Setup(context => context.Request.Path).Returns(path);
            httpContext.Setup(context => context.Connection.RemoteIpAddress).Returns(remoteIpAddress);

            WeatherForecastController weatherForecastController = new WeatherForecastController(loggerMock.Object);

            weatherForecastController.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext.Object
            };


            // Act
            var result = weatherForecastController.GetData();

            // Assert
            var actionResult = Assert
              .IsType<ActionResult<DataModel>>(result);
            // get OkObjectResult from ActionResult
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);

            // get value from OkObjectResult
            var response = Assert.IsType<DataModel>(okObjectResult.Value);

            Assert.NotNull(response);
            Assert.Equal(path, response.Path);
            Assert.Equal(remoteIpAddress.ToString(), response.Ip);

        }
    }
}
