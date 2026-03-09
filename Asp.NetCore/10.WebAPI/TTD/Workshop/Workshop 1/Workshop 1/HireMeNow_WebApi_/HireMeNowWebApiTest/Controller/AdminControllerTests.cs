using HireMeNow_WebApi.API.Admin.RequestObjects;
using HireMeNow_WebApiTests.Fixtures;
using Microsoft.VisualStudio.TestPlatform.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HireMeNowWebApiTest.Controller
{
    public class AdminControllerTests: IClassFixture<ApiWebApplicationFactory>
    {
        HttpClient _httpClient = new HttpClient();   
        public AdminControllerTests()
        {
            ApiWebApplicationFactory _factory = new ApiWebApplicationFactory();

            _httpClient = _factory.CreateClient();

        }
        [Fact]
        public async Task Post_Login_ReturnsOkResult()
        {
            //Arrange
            AdminLoginRequests data = new AdminLoginRequests
            { Email= "user@example.com",
            Password= "123"
            };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Act
            var response = await _httpClient.PostAsync("https://your-api-base-url/api/v1/Admin/login", httpContent);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);   


        }
        [Fact]
        public async Task Post_Login_ReturnsBadResult()
        {
            //Arrange
            AdminLoginRequests data = new AdminLoginRequests
            {
                Email = "user@example.com",
                Password = "12"
            };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Act
            var response = await _httpClient.PostAsync("https://your-api-base-url/api/v1/Admin/login", httpContent);

            //Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);


        }

    }
}
