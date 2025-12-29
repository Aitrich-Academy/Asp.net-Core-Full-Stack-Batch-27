using Microsoft.VisualStudio.TestPlatform.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TDDtest.Fixtures;
using test.NewFolder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TDDtest.Controllers
{
    public class AddControllerTests: IClassFixture<ApiWebApplicationFactory>
    {
        /*This Http client stimulates the real client,
         allowing end to end testing of your API*/
        HttpClient _httpClient = new HttpClient();

        public AddControllerTests()
        {
           ApiWebApplicationFactory factory= new ApiWebApplicationFactory();
            _httpClient = factory.CreateClient();

        }
        /*This is an asynchronous unit test method (returns Task)
         * and will be executed by the test runner (xUnit in your case).

        It's testing that a POST request to your /api/v1/add endpoint 
        returns a successful response with the correct result when given valid data.*/
        [Fact]
        public async Task Post_Add_return_Sucess()
        {
            //Arrange
            //Arrange - Prepare data and content for the POST request.
            Data ob = new Data()
            {
                a = 10,
                b = 12
        };
          
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(ob), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            /*Serializes the Data object to JSON using JsonConvert.SerializeObject.

            Wraps the JSON string in an HttpContent object with UTF-8 encoding.

            Sets the content type header to "application/json" so the API knows it's receiving JSON.

            */

            //Act
            //Act -	Send POST request to the API and capture the response.
            var response = await _httpClient.PostAsync("https://your-api-base-url/api/v1/add", httpContent);
            /*Sends an HTTP POST request to your API's add endpoint.

            Includes the JSON content created above in the request body.

            Awaits the response from the API.*/

            //Assert
            //Assert -	Check the HTTP status code and verify the response body result is as expected.

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            /*Asserts that the response has a status code of 200 OK, 
             * meaning the request was successfully handled by the API.*/

            

            var resultString = await response.Content.ReadAsStringAsync();
            int result = int.Parse(resultString);
            /*Reads the response body as a string.

            Parses it into an integer (assuming your API just returns 
            the result directly as a number in plain text).*/




            // Verify the result matches the expected value
            Assert.Equal(22, result); // 10 + 12 = 22
        }
        [Fact]
        public async Task Post_Add_invalidinput_return_Badrequest()
        {
            //Arrange
            Data ob = new Data()
            {
                a = 2,
                b = 12
            };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(ob), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Act
            var response = await _httpClient.PostAsync("https://your-api-base-url/api/v1/add", httpContent);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
           

        }

    }
}
