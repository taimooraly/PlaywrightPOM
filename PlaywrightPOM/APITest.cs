using Microsoft.CodeAnalysis;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using RazorEngine.Compilation.ImpromptuInterface.InvokeExt;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml.Linq;

namespace PlaywrightPOM
{
    [TestClass]
    public class APITest : PlaywrightTest
    {
        private IAPIRequestContext Request = null;
        API api = new API();
        
        [TestInitialize]
        public void TestInit()
        {
            api.Playwright = Playwright;
        }

        [TestMethod]
        public async Task GET()
        {
            Request = await Playwright.APIRequest.NewContextAsync(new()
            {
                // All requests we send go to this API endpoint.
                BaseURL = "http://localhost:3000/",
            });

            var comments = await Request.GetAsync(@"comments/");


            Assert.IsTrue(comments.Ok);
            
            var commentsJsonResponse = await comments.JsonAsync();
            JsonElement? comment = null;
            foreach (JsonElement commentObj in commentsJsonResponse?.EnumerateArray())
            {
                if (commentObj.TryGetProperty("body", out var id) == true)
                {
                    if (id.GetString() == "some comment")
                    {
                        comment = commentObj;
                    }
                }
            }
            Assert.IsNotNull(comment);
            Assert.AreEqual("some comment", comment?.GetProperty("body").GetString());
        }

        [TestMethod]
        public async Task POST()
        {
            Request = await Playwright.APIRequest.NewContextAsync(new()
            {
                // All requests we send go to this API endpoint.
                BaseURL = "http://localhost:3000/",
            });

            var data = new Dictionary<string, string>();
            data.Add("id", "2");
            data.Add("body", "Buggy Tool");
            data.Add("postId", "1");
            var newcomment = await Request.PostAsync("/comments", new() { DataObject = data });
            Assert.IsTrue(newcomment.Ok);

            var comments = await Request.GetAsync(@"comments/");
            Assert.IsTrue(comments.Ok);
            var commentsJsonResponse = await comments.JsonAsync();
            JsonElement? comment = null;
            foreach (JsonElement commentObj in commentsJsonResponse?.EnumerateArray())
            {
                if (commentObj.TryGetProperty("body", out var id) == true)
                {
                    if (id.GetString() == "Buggy Tool")
                    {
                        comment = commentObj;
                    }
                }
            }
            Assert.IsNotNull(comment);
            Assert.AreEqual("Buggy Tool", comment?.GetProperty("body").GetString());
        }

        [TestMethod]
        public async Task PUT()
        {
            Request = await Playwright.APIRequest.NewContextAsync(new()
            {
                // All requests we send go to this API endpoint.
                BaseURL = "http://localhost:3000/",
            });

            var data = new Dictionary<string, string>();
            data.Add("id", "4");
            data.Add("body", "Buggy Tool Updated");
            data.Add("postId", "1");
            var newcomment = await Request.PutAsync("/comments/4", new() { DataObject = data });
            Assert.IsTrue(newcomment.Ok);

            var comments = await Request.GetAsync(@"comments/");
            Assert.IsTrue(comments.Ok);
            var commentsJsonResponse = await comments.JsonAsync();
            JsonElement? comment = null;
            foreach (JsonElement commentObj in commentsJsonResponse?.EnumerateArray())
            {
                if (commentObj.TryGetProperty("body", out var id) == true)
                {
                    if (id.GetString() == "Buggy Tool Updated")
                    {
                        comment = commentObj;
                    }
                }
            }
            Assert.IsNotNull(comment);
            Assert.AreEqual("Buggy Tool Updated", comment?.GetProperty("body").GetString());
        }

        [TestMethod]
        public async Task PATCH()
        {
            Request = await Playwright.APIRequest.NewContextAsync(new()
            {
                // All requests we send go to this API endpoint.
                BaseURL = "http://localhost:3000/",
            });

            var data = new Dictionary<string, string>();
            data.Add("body", "Buggy Tool");
          
            var newcomment = await Request.PatchAsync("/comments/4", new() { DataObject = data });
            Assert.IsTrue(newcomment.Ok);

            var comments = await Request.GetAsync(@"comments/");
            Assert.IsTrue(comments.Ok);
            var commentsJsonResponse = await comments.JsonAsync();
            JsonElement? comment = null;
            foreach (JsonElement commentObj in commentsJsonResponse?.EnumerateArray())
            {
                if (commentObj.TryGetProperty("body", out var id) == true)
                {
                    if (id.GetString() == "Buggy Tool")
                    {
                        comment = commentObj;
                    }
                }
            }
            Assert.IsNotNull(comment);
            Assert.AreEqual("Buggy Tool", comment?.GetProperty("body").GetString());
        }

        [TestMethod]
        public async Task DELETE()
        {
            Request = await Playwright.APIRequest.NewContextAsync(new()
            {
                // All requests we send go to this API endpoint.
                BaseURL = "http://localhost:3000/",
            });

            var newcomment = await Request.DeleteAsync("/comments/4");
            Assert.IsTrue(newcomment.Ok);

            var comments = await Request.GetAsync(@"comments/");
            Assert.IsTrue(comments.Ok);
            var commentsJsonResponse = await comments.JsonAsync();
            JsonElement? comment = null;
            foreach (JsonElement commentObj in commentsJsonResponse?.EnumerateArray())
            {
                if (commentObj.TryGetProperty("id", out var id) == true)
                {
                    if (!id.ToString().Contains("4"))
                    {
                        comment = commentObj;
                    }
                }
            }
            Assert.IsNotNull(comment);           
        }

        [TestMethod]
        public async Task GET_TC_01()
        {     
            var getResponse =  await api.GETRequest(@"http://localhost:3000/comments");

            JsonElement? resData = null;
            foreach (JsonElement responseObj in getResponse?.EnumerateArray())
            {
                if (responseObj.TryGetProperty("body", out var id) == true)
                {
                    if (id.GetString() == "Amir")
                    {
                        resData = responseObj;
                    }
                }
            }
            Assert.IsNotNull(resData);
            Assert.AreEqual("Amir", resData?.GetProperty("body").GetString());
        }

        [TestMethod]
        public async Task GET_TC_02()
        {
            var getResponse = await api.GETRequest(@"http://localhost:3000/comments", "body", "Buggy Tool");        
        }

        [TestMethod]
        public async Task POST_TC_01()
        {
            var data = new Dictionary<string, string>();
            data.Add("id", "4");
            data.Add("body", "Samjah shayad agia hai...");
            data.Add("post_Id", "3");

            var getResponse = await api.POSTResponse(@"http://localhost:3000/comments", data);
        }

        [TestMethod]
        public async Task PUT_TC_01()
        {
            var data = new Dictionary<string, string>();
            data.Add("id", "6");
            data.Add("title", "Smajah agia");
            data.Add("author", "2");

            var getResponse = await api.PUTResponse(@"http://localhost:3000/comments/4", data);
        }

        [TestMethod]
        public async Task PATCH_TC_01()
        {
            var data = new Dictionary<string, string>();
            data.Add("id", "5");
            data.Add("title", "My post updated");
            data.Add("author", "huda");

            var getResponse = await api.PUTResponse(@"http://localhost:3000/comments/4", data);
        }

        [TestMethod]
        public async Task DELETE_TC_01()
        {      
            var getResponse = await api.DELETEResponse(@"http://localhost:3000/comments/4");
        }

        //public async Task<JsonElement?> POSTResponse(string endpoint, Dictionary<string, string> data)
        //{
        //    Request = await Playwright.APIRequest.NewContextAsync();
        //    var postResponse = await Request.PostAsync(endpoint, new() { DataObject = data });
        //    Assert.IsTrue(postResponse.Ok);
        //    var jsonResponse = await postResponse.JsonAsync();
        //    return jsonResponse;
        //}

        [TestMethod]
        public async Task GET_new()
        {
            Request = await Playwright.APIRequest.NewContextAsync();

            var employee = await Request.GetAsync(@"https://dummy.restapiexample.com/api/v1/employees");
            Assert.IsTrue(employee.Ok);
            var employeeJsonResponse = await employee.JsonAsync();
        }
    }
}