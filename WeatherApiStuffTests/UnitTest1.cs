using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeatherAPIStuff;
using WeatherAPIStuff.Controllers;
using WeatherAPIStuff.Weather_Services;
using Xunit;

namespace WeatherApiStuffTests
{
    public class UnitTest1
    {
        [Theory, AutoData]
        public void Test1(string stringas)
        {
            //Arrange
            var RepMock = new Mock<IWeatherServices>();
            var loggerMock = new Mock<ILogger<WeatherController>>();
            //var httpContext = new DefaultHttpContext();
            //var controllerContext = new ControllerContext() { HttpContext = httpContext};
            var sut = new WeatherController(loggerMock.Object, RepMock.Object) /*{ ControllerContext = controllerContext}*/;
            RepMock.Setup(x => x.GetINformation(stringas)).Returns((List<String>)null);
            //Act
            var testResult = sut.Indexs(It.IsAny<string>());
            //Assert
            var type = testResult.Result.GetType();
            Assert.Equal("NotFoundResult", type.Name);
        }
        [Theory, AutoData]
        public async void Test_If_Returns_Correct_Http_Request_Content(string city)
        {
            //Arrange
            var mockMessageHandler = new Mock<HttpMessageHandler>();
            mockMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).
                ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("Random Weather Data") });
            HttpClient mockClient = new HttpClient(mockMessageHandler.Object);
            var undertest = new WeatherServices(mockClient);         
            //Act
            var result = await undertest.HttpClientExtension(city);
            //Assert
            var expected = "Random Weather Data";
            Assert.Equal(expected, result);
        }
        [Theory, AutoData]
        public async void Test_When_Request_Is_Not_Ok(string city)
        {
           
            //Arrange
            try
            {
                var mockMessageHandler = new Mock<HttpMessageHandler>();
                mockMessageHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()).
                    ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, Content = new StringContent("Random Weather Data") });
                HttpClient mockClient = new HttpClient(mockMessageHandler.Object);
                var undertest = new WeatherServices(mockClient);
                //Act
                var result = await undertest.HttpClientExtension(city);
               
            }
            //Assert
            catch (Exception e)
            {
                var expected = "Random Weather Data";
                var d = e.GetType();
                Assert.IsType<Exception>(e);
            }
        }
            
        
    }
}
