using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HireMeNow_WebApiTests.Fixtures;
using HireMeNow_WebApi.API.JobSeeker.RequestObjects;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using HireMeNow_WebApi.API.JobSeeker;
using AutoMapper;


namespace HireMeNow_WebApiTests.Controller
{
    public class JobseekerControllerTest:IClassFixture<ApiWebApplicationFactory>
    {
        HttpClient _httpClient = new HttpClient();
       

        public JobseekerControllerTest()
        {
            ApiWebApplicationFactory _factory = new ApiWebApplicationFactory();
        
            _httpClient = _factory.CreateClient();
           

        }
        [Fact]
        public async Task Post_CreateJobSeekerSignupRequest_ReturnsOkResult()
        {//arrange
            var requestData = new JobSeekerSignupRequest
            {
                UserName = "Ram",
                FirstName = "Ram",
                LastName = "Lal",
                Email = "ram1@gmailcom",
                Phone = "9072493551"


            };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Act
            var response = await _httpClient.PostAsync("https://your-api-base-url/api/v1/job-seeker/signup", httpContent);
            //Assert
               Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        
        [Fact]
        public async Task Post_CreateJobSeekerSignupRequest_withoutPhoneFirstName_ReturnsbadResult()
        {
            var requestData = new JobSeekerSignupRequest
            {
                UserName = "Rasiya",
                FirstName = "",
                LastName = "Shajeer",
                Email = "razzrasiya@gmail.com",
                Phone = "9072493551"


            };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Act
            var response = await _httpClient.PostAsync("https://your-api-base-url/api/v1/job-seeker/signup", httpContent);
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [Fact]
        public async Task Post_CreateJobSeekerSignupRequest_WithoutEmailReturnsbadResult()
        {
            //Arange
            var requestData = new JobSeekerSignupRequest
            {
                UserName = "Rasiya",
                FirstName = "Shajeer",
                LastName = "Shajeer",
                Email = "",
                Phone = "9072493551"


            };
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Act
            var response = await _httpClient.PostAsync("https://your-api-base-url/api/v1/job-seeker/signup", httpContent);
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [Fact]
        public async Task Get_VerifyJobSeekerEmail_WithvalidjobSeekerSignupRequestId_Returns_Sucess()
        {
            //Arange
            var jobSeekerSignupRequestId = new Guid("7527DF2C-E9AA-415D-6472-08DC19A62A53");
          
            // Act
            var response = await _httpClient.GetAsync($"https://your-api-base-url/api/v1/job-seeker/signup/{jobSeekerSignupRequestId}/verify-email");
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        [Fact]
        public async Task Get_VerifyJobSeekerEmail_WithInvalidjobSeekerSignupRequestId_Returns_BadResult()
        {
            //Arange
            var jobSeekerSignupRequestId = new Guid("97E443B7-95B5-422E-ACEF-08DC1429E5D0");

            // Act
            var response = await _httpClient.GetAsync($"https://your-api-base-url/api/v1/job-seeker/signup/{jobSeekerSignupRequestId}/verify-email");
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [Fact]
        public async Task Post_createJobSeekerSignupRequest_WithvalidjobSeekerSignupRequestId_Returns_Success()
        {
            //Arange
            var jobSeekerSignupRequestId = new Guid("7527DF2C-E9AA-415D-6472-08DC19A62A53");
            string password = "your_password";
            // Convert the password to JSON format
            var jsonContent = new StringContent($"\"{password}\"", Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PostAsync($"https://your-api-base-url/api/v1/job-seeker/signup/{jobSeekerSignupRequestId}/set-password",jsonContent);
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        [Fact]
        public async Task Post_createJobSeekerSignupRequest_WithInvalidjobSeekerSignupRequestId_Returns_BadRequest()
        {
            //Arange
            var jobSeekerSignupRequestId = Guid.Empty;
            string password = "your_password";
            // Convert the password to JSON format
            var jsonContent = new StringContent($"\"{password}\"", Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PostAsync($"https://your-api-base-url/api/v1/job-seeker/signup/{jobSeekerSignupRequestId}/set-password", jsonContent);
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [Fact]
        public async Task Post_Login_WithvalidEmailId_and_Password_Returns_Success()
        { //Arange
            JobSeekerLoginRequest data=new JobSeekerLoginRequest();
            data.Email = "ram1@gmailcom";
            data.Password = "your_password";


            // Convert the password to JSON format
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // Act
            var response = await _httpClient.PostAsync($"https://your-api-base-url/api/v1/job-seeker/login", httpContent);
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        [Fact]
        public async Task Post_Login_WithInvalidEmailId_and_Password_Returns_BadRequest()
        { //Arange
            JobSeekerLoginRequest data = new JobSeekerLoginRequest();
            data.Email = "razzrasi@gmail.com";
            data.Password = "123";


            // Convert the password to JSON format
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // Act
            var response = await _httpClient.PostAsync($"https://your-api-base-url/api/v1/job-seeker/login", httpContent);
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        //[Fact]
        //public async Task Post_UploadResume_Returns_Success()
        //{ //Arange
        //    UploadResumeRequest uploadResumeRequest = new UploadResumeRequest();
        //    var formData = new MultipartFormDataContent();
        //    formData.Add(new StringContent("3AA9FB30-7D1C-429C-E40E-08DC142A37C6"), "uploadResumeRequest.jobSeekerId");
        //    formData.Add(new StringContent("36A0C5D2-9399-493D-8EF8-4B00C9981B5E"), "uploadResumeRequest.profileId");
        //    formData.Add(new StringContent("Test"), "uploadResumeRequest.profileName");
        //    formData.Add(new StringContent("Test"), "uploadResumeRequest.profileSummary");
        //    formData.Add(new StringContent("Test"), "uploadResumeRequest.title");
        //    var dummyImageStream = new MemoryStream(new byte[] { 0x1, 0x2, 0x3 });
        //    formData.Add(new StreamContent(dummyImageStream), "Image", "image.jpg");

        //    // Log the data being sent
        //    Console.WriteLine($"Data being sent: {await formData.ReadAsStringAsync()}");

        //    // Act
        //    var response = await _httpClient.PostAsync("https://your-api-base-url/api/v1/job-seeker/upload-resume", formData);

        //    // Log the response status code
        //    Console.WriteLine($"Response Status Code: {response.StatusCode}");

        //    // Log the response content
        //    var responseContent = await response.Content.ReadAsStringAsync();
        //    Console.WriteLine($"Response Content: {responseContent}");

        //    // Assert
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //}


    }
    }
