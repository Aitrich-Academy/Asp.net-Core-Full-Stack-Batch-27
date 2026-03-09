using Domain.Models;
using HireMeNow_WebApi.JobSeeker;
using HireMeNow_WebApiTests.Fixtures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HireMeNow_WebApiTests.Controller
{
    public class JobSeekerProfileControllerTests
    {
        HttpClient _httpClient = new HttpClient();

        public JobSeekerProfileControllerTests()
        {
            ApiWebApplicationFactory _factory = new ApiWebApplicationFactory();

            _httpClient = _factory.CreateClient();
        }
        [Fact]
        public async Task Post_AddQualificationToProfile_Withvalid_jobseekerId_profileId_return_Success()
        {
            //arrange
            var jobseekerId = new Guid("886EEDFF-8992-49C3-8F4C-08DC19A6D385");
            var profileId = new Guid("CE833BBD-8C2E-4337-BC20-753759B033F5");
            QualificationRequest data = new QualificationRequest
            {
                Name = "Btech",
                Description = "Computer Science"
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmFtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoicmFtMUBnbWFpbGNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6Ijg4NmVlZGZmLTg5OTItNDljMy04ZjRjLTA4ZGMxOWE2ZDM4NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkpPQl9TRUVLRVIiLCJleHAiOjE3MDU5OTk4NzF9.Pi8oQYzGbBogRQLICv9n8osdT7YpfQIpbXvwUPIY0R7-3CI7ERhy58_-sll0Q5KlOv2K71uP9eyg2TkQ7KSJ4Q");
            //act
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://your-api-base-url/api/v1/{jobseekerId}/profile/{profileId}/Qualification", content);
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);


        }
        [Fact]
        public async Task Post_AddQualificationToProfile_WithInvalid_jobseekerId_profileId_return_BadRequest()
        {
            //arrange
            var jobseekerId = Guid.NewGuid();
            var profileId = new Guid("CE833BBD-8C2E-4337-BC20-753759B033F5");
            QualificationRequest data = new QualificationRequest
            {
                Name = "Btech",
                Description = "Computer Science"
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmFtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoicmFtMUBnbWFpbGNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6Ijg4NmVlZGZmLTg5OTItNDljMy04ZjRjLTA4ZGMxOWE2ZDM4NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkpPQl9TRUVLRVIiLCJleHAiOjE3MDU5OTk4NzF9.Pi8oQYzGbBogRQLICv9n8osdT7YpfQIpbXvwUPIY0R7-3CI7ERhy58_-sll0Q5KlOv2K71uP9eyg2TkQ7KSJ4Q");
            //act
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://your-api-base-url/api/v1/{jobseekerId}/profile/{profileId}/Qualification", content);
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);


        }
        [Fact]
        public async Task Post_AddQualificationToProfile_jobseekerId_WithInvalid_profileId_return_BadRequest()
        {
            //arrange
            var jobseekerId = new Guid("886EEDFF-8992-49C3-8F4C-08DC19A6D385");
            var profileId = new Guid();
            QualificationRequest data = new QualificationRequest
            {
                Name = "Btech",
                Description = "Computer Science"
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmFtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoicmFtMUBnbWFpbGNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6Ijg4NmVlZGZmLTg5OTItNDljMy04ZjRjLTA4ZGMxOWE2ZDM4NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkpPQl9TRUVLRVIiLCJleHAiOjE3MDU5OTk4NzF9.Pi8oQYzGbBogRQLICv9n8osdT7YpfQIpbXvwUPIY0R7-3CI7ERhy58_-sll0Q5KlOv2K71uP9eyg2TkQ7KSJ4Q");
            //act
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://your-api-base-url/api/v1/{jobseekerId}/profile/{profileId}/Qualification", content);
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);


        }
        [Fact]
        public async Task Post_AddQualificationToProfile_Withvalid_jobseekerId_profileId_without_Qualification_name_return_BadRequest()
        {
            //arrange
            var jobseekerId = new Guid("886EEDFF-8992-49C3-8F4C-08DC19A6D385");
            var profileId = new Guid("CE833BBD-8C2E-4337-BC20-753759B033F5");
            QualificationRequest data = new QualificationRequest
            {

                Description = "Computer Science"
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmFtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoicmFtMUBnbWFpbGNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6Ijg4NmVlZGZmLTg5OTItNDljMy04ZjRjLTA4ZGMxOWE2ZDM4NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkpPQl9TRUVLRVIiLCJleHAiOjE3MDU5OTk4NzF9.Pi8oQYzGbBogRQLICv9n8osdT7YpfQIpbXvwUPIY0R7-3CI7ERhy58_-sll0Q5KlOv2K71uP9eyg2TkQ7KSJ4Q");
            //act
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"https://your-api-base-url/api/v1/{jobseekerId}/profile/{profileId}/Qualification", content);
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);


        }
        [Fact]
        public async Task Get_GetProfile_with_Valid_jobseekerId_return_Succes()
        {
            //arrange
            var jobseekerId = new Guid("886EEDFF-8992-49C3-8F4C-08DC19A6D385");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmFtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoicmFtMUBnbWFpbGNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6Ijg4NmVlZGZmLTg5OTItNDljMy04ZjRjLTA4ZGMxOWE2ZDM4NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkpPQl9TRUVLRVIiLCJleHAiOjE3MDU5OTk4NzF9.Pi8oQYzGbBogRQLICv9n8osdT7YpfQIpbXvwUPIY0R7-3CI7ERhy58_-sll0Q5KlOv2K71uP9eyg2TkQ7KSJ4Q");
            //Act
            var response = await _httpClient.GetAsync($"https://your-api-base-url/api/v1/{jobseekerId}/profiledetails");
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        [Fact]
        public async Task Get_GetProfile_with_InValid_jobseekerId_return_result()
        {
            //arrange
            var jobseekerId = Guid.NewGuid();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmFtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoicmFtMUBnbWFpbGNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6Ijg4NmVlZGZmLTg5OTItNDljMy04ZjRjLTA4ZGMxOWE2ZDM4NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkpPQl9TRUVLRVIiLCJleHAiOjE3MDU5OTk4NzF9.Pi8oQYzGbBogRQLICv9n8osdT7YpfQIpbXvwUPIY0R7-3CI7ERhy58_-sll0Q5KlOv2K71uP9eyg2TkQ7KSJ4Q");
            //Act
            var response = await _httpClient.GetAsync($"https://your-api-base-url/api/v1/{jobseekerId}/profiledetails");
            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }

        [Fact]

        public async Task GetQualification_with_Valid_profileId_return_resultSuccess()
        {
            //arrange
            var profileId = new Guid("CE833BBD-8C2E-4337-BC20-753759B033F5");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmFtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoicmFtMUBnbWFpbGNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6Ijg4NmVlZGZmLTg5OTItNDljMy04ZjRjLTA4ZGMxOWE2ZDM4NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkpPQl9TRUVLRVIiLCJleHAiOjE3MDYwNzc0NjR9.clqVprf-5fq4oHQ1Jj9tW0zOPfTKZtmub-ByZc9ZtS5OdiPpA6dWWL_YwXEjsZF-qtkpU5ZM_2sTyoALDacsYQ");
            //Act

            var response = await _httpClient.GetAsync($"https://your-api-base-url/api/v1/profile/{profileId}/Qualification");
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Successful Response: {content}");
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        [Fact]
        public async Task GetQualification_with_InValid_profileId_return_resultSuccess()
        {
            //arrange
            var profileId = Guid.NewGuid();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmFtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoicmFtMUBnbWFpbGNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6Ijg4NmVlZGZmLTg5OTItNDljMy04ZjRjLTA4ZGMxOWE2ZDM4NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkpPQl9TRUVLRVIiLCJleHAiOjE3MDYwNzc0NjR9.clqVprf-5fq4oHQ1Jj9tW0zOPfTKZtmub-ByZc9ZtS5OdiPpA6dWWL_YwXEjsZF-qtkpU5ZM_2sTyoALDacsYQ");
            //Act

            var response = await _httpClient.GetAsync($"https://your-api-base-url/api/v1/profile/{profileId}/Qualification");
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Successful Response: {content}");
            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }
        [Fact]
        public async Task UpdateJobSeekerProfile_with_InValid_profileId_return_resultSuccess()
        {
            //arrange
            var profileId = Guid.NewGuid();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmFtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoicmFtMUBnbWFpbGNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6Ijg4NmVlZGZmLTg5OTItNDljMy04ZjRjLTA4ZGMxOWE2ZDM4NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkpPQl9TRUVLRVIiLCJleHAiOjE3MDYwNzc0NjR9.clqVprf-5fq4oHQ1Jj9tW0zOPfTKZtmub-ByZc9ZtS5OdiPpA6dWWL_YwXEjsZF-qtkpU5ZM_2sTyoALDacsYQ");
            //Act

            var response = await _httpClient.GetAsync($"https://your-api-base-url/api/v1/profile/{profileId}/Qualification");
            string content = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Successful Response: {content}");
            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }
        [Fact]
        public async Task PUT_UpdateJobSeekerProfile_ReturnsSuccess()
        {


            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent("3AA9FB30-7D1C-429C-E40E-08DC142A37C6"), "JobseekerId");
            formData.Add(new StringContent("Raz"), "UserName");
            formData.Add(new StringContent("Test"), "FirstName");
            formData.Add(new StringContent("Test"), "LastName");
            formData.Add(new StringContent("89765432112"), "Phone");
            formData.Add(new StringContent("123"), "Password");
            var dummyImageStream = new MemoryStream(new byte[] { 0x1, 0x2, 0x3 });
            formData.Add(new StreamContent(dummyImageStream), "Image", "image.jpg");
         
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmFtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoicmFtMUBnbWFpbGNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6Ijg4NmVlZGZmLTg5OTItNDljMy04ZjRjLTA4ZGMxOWE2ZDM4NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkpPQl9TRUVLRVIiLCJleHAiOjE3MDYwNzc0NjR9.clqVprf-5fq4oHQ1Jj9tW0zOPfTKZtmub-ByZc9ZtS5OdiPpA6dWWL_YwXEjsZF-qtkpU5ZM_2sTyoALDacsYQ");
            //Act

            var response = await _httpClient.PutAsync("https://your-api-base-url/api/v1/UpdateJobSeekerProfile", formData);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Content: {responseContent}");
            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        [Fact]
        public async Task PUT_UpdateJobSeekerProfile_WithInvalid_JobseekerId_ReturnsBadRequest()
        {


            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(""), "JobseekerId");
            formData.Add(new StringContent("Raz"), "UserName");
            formData.Add(new StringContent("Test"), "FirstName");
            formData.Add(new StringContent("Test"), "LastName");
            formData.Add(new StringContent("89765432112"), "Phone");
            formData.Add(new StringContent("123"), "Password");
            var dummyImageStream = new MemoryStream(new byte[] { 0x1, 0x2, 0x3 });
            formData.Add(new StreamContent(dummyImageStream), "Image", "image.jpg");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmFtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoicmFtMUBnbWFpbGNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6Ijg4NmVlZGZmLTg5OTItNDljMy04ZjRjLTA4ZGMxOWE2ZDM4NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkpPQl9TRUVLRVIiLCJleHAiOjE3MDYwNzc0NjR9.clqVprf-5fq4oHQ1Jj9tW0zOPfTKZtmub-ByZc9ZtS5OdiPpA6dWWL_YwXEjsZF-qtkpU5ZM_2sTyoALDacsYQ");

            var response = await _httpClient.PutAsync("https://your-api-base-url/api/v1/UpdateJobSeekerProfile", formData);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Content: {responseContent}");
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task PUT_UpdateJobSeekerProfile_WithoutInvalid_FirstName_ReturnsBadRequest()
        {


            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(""), "JobseekerId");
            formData.Add(new StringContent("Raz"), "UserName");
            formData.Add(new StringContent(""), "FirstName");
            formData.Add(new StringContent("Test"), "LastName");
            formData.Add(new StringContent("89765432112"), "Phone");
            formData.Add(new StringContent("123"), "Password");
            var dummyImageStream = new MemoryStream(new byte[] { 0x1, 0x2, 0x3 });
            formData.Add(new StreamContent(dummyImageStream), "Image", "image.jpg");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmFtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoicmFtMUBnbWFpbGNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6Ijg4NmVlZGZmLTg5OTItNDljMy04ZjRjLTA4ZGMxOWE2ZDM4NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkpPQl9TRUVLRVIiLCJleHAiOjE3MDYwNzc0NjR9.clqVprf-5fq4oHQ1Jj9tW0zOPfTKZtmub-ByZc9ZtS5OdiPpA6dWWL_YwXEjsZF-qtkpU5ZM_2sTyoALDacsYQ");

            var response = await _httpClient.PutAsync("https://your-api-base-url/api/v1/UpdateJobSeekerProfile", formData);
            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Response Content: {responseContent}");
            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public  async Task Post_AddProfile_Withvalid_data_return_Success()
        {
            JobseekerProfileRequest data=new JobseekerProfileRequest();
            data.JobSeekerId=  new Guid("886EEDFF-8992-49C3-8F4C-08DC19A6D385");
            data.ProfileName = "Developer";
            data.ProfileSummary = ".Net";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmFtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoicmFtMUBnbWFpbGNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6Ijg4NmVlZGZmLTg5OTItNDljMy04ZjRjLTA4ZGMxOWE2ZDM4NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkpPQl9TRUVLRVIiLCJleHAiOjE3MDYwNzc0NjR9.clqVprf-5fq4oHQ1Jj9tW0zOPfTKZtmub-ByZc9ZtS5OdiPpA6dWWL_YwXEjsZF-qtkpU5ZM_2sTyoALDacsYQ");


            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://your-api-base-url/api/v1/AddProfile", content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Post_AddProfile_WithInvalid_data_return_Badresults()
        {
            JobseekerProfileRequest data = new JobseekerProfileRequest();
            data.JobSeekerId =Guid.NewGuid();   
            data.ProfileName = "Developer";
            data.ProfileSummary = ".Net";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiUmFtIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoicmFtMUBnbWFpbGNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3NpZCI6Ijg4NmVlZGZmLTg5OTItNDljMy04ZjRjLTA4ZGMxOWE2ZDM4NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkpPQl9TRUVLRVIiLCJleHAiOjE3MDYwNzc0NjR9.clqVprf-5fq4oHQ1Jj9tW0zOPfTKZtmub-ByZc9ZtS5OdiPpA6dWWL_YwXEjsZF-qtkpU5ZM_2sTyoALDacsYQ");


            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://your-api-base-url/api/v1/AddProfile", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }



    }
}
