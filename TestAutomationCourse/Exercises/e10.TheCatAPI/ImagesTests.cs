using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.IO;

namespace TestAutomationCourse.Exercises.e10.TheCatAPI
{
    [TestFixture]
    public class ImagesTests
    {
        string apiToken = "ced92260-1b3b-4b60-aaa4-474eb9c1b9a1";
        [Test]
        public async Task Images_Search()
        {
            RestClient client = new RestClient("https://api.thecatapi.com/v1/");
            RestRequest request = new RestRequest("images/search?breed_ids=beng&include_breeds=true");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-api-key", apiToken);
            var json= await client.GetAsync(request);
            Assert.That(json.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public async Task Images_Upload()
        {
            var client = new RestClient("https://api.thecatapi.com/v1/images/upload");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "multipart/form-data; boundary=<calculated when request is sent>");
            request.AddHeader("x-api-key", apiToken);
            request.AddFile("file", @"C:\Users\מולועלם דפרשה\Desktop\CSharp-Automation\TestAutomationCourse\Exercises\e10.TheCatAPI\cat1.jpeg");
            request.AddParameter("sub_id", "user789");
            var a = await client.ExecutePostAsync(request);
        }

        [Test]
        public async Task DeleteImage_Id()
        {
            var image_id = 0;
            var client = new RestClient($"https://api.thecatapi.com/v1/images/{image_id}");
         
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-api-key", "example-api-key-for-your-account");
            var response =await client.DeleteAsync(request);
            Console.WriteLine(response.Content);
        }
    }
}
