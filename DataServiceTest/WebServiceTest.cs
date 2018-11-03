using DataLayer;
using System;
using System.Linq;
using Xunit;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjoctPortfolioTests
{
    public class WebServiceTest
    {
        private const string AnswersApi = "http://localhost:5001/api/answers";
        private const string QuestionsApi = "http://localhost:5001/api/questions";
        private const string SearchHostoryApi = "http://localhost:5001/api/searchhistory";
        private const string AnnotationsApi = "http://localhost:5001/api/annotation";
        private const string MarkApi = "http://localhost:5001/api/mark";

        //Answers
        [Fact]
        public void ApiAnswers_GetWithNoArguments_OkAndAllAnswers()
        {
            var (data, statusCode) = GetArray(AnswersApi);

            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal(11392, data.Count);
            Assert.Equal("<p>You should clear:both after the floats.</p>&#xA;&#xA;<pre><code>&lt;div style=\"clear:both\"&gt;&lt;/div&gt;&#xA;</code></pre>&#xA;", data.First()["body"]);
            Assert.Equal(1228347, data.First()["authorId"]);
            Assert.Equal(2, data.First()["postType"]);
        }

        [Fact]
        public void ApiAnswers_GetWithValidParentId_okAndAnswer()
        {
            var (answer, statusCode) = GetArray($"{AnswersApi}/9844982");

            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal(4 , answer[0]["score"]);
            //Assert.Equal(9844982, answer["parentId"]);
        }

        [Fact]
        public void ApiAnswers_GetApectedAnswerId_OkAndAnswer()
        {
            var (answer, statusCode) = GetObject($"{AnswersApi}/acceptedanswer/15831991");
            //($"{ProductsApi}/category/1")
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal(0, (int)answer.GetValue("score"));
        }
        
        /*
        [Fact]
        public void ApiAnswers_GetWithInvalidAnswerId_()
        {
            var (answer, statusCode) = GetArray($"{AnswersApi}/-1");

            Assert.Equal(HttpStatusCode.NotFound, statusCode);
        } */

        //Questions
        [Fact]
        public void ApiQuestions_GetWithNoArguments_OkAndAllQuestions()
        {
            var (data, statusCode) = GetObject(QuestionsApi);

            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal(10, data.GetValue("items").Count());
            //Assert.Equal("<p>I'm setting my console full screen but I also want to hide the task bar and the start button in VB.NET using Visual Studio 2010</p>&#xA;&#xA;<p>Thanks</p>&#xA;", data.First()["body"]);
            //Assert.Equal(1365365, data.First()["authorId"]);
            //Assert.Equal(1, data.First()["postType"]);
        }

        [Fact]
        public void ApiQuestions_GetQuestion_WithValidId()
        {
            var (question, statusCode) = GetObject($"{QuestionsApi}/13649012");

            Assert.Equal(HttpStatusCode.OK, statusCode);
            //Assert.Equal(13649012, question["postId"]);
        } 
        [Fact]
        public void ApiAnnotation_PostAnnotation()
        {
            var annotation = new
            {
                Body = "Annotation post",
                UserId= 51,
                PostId= 13649012

            };
            var (annotations, statusCode) = PostData(AnnotationsApi,annotation);
            Assert.Equal(HttpStatusCode.Created,statusCode);
        }

     
        //Helpers
        (JArray, HttpStatusCode) GetArray(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JArray)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JObject, HttpStatusCode) GetObject(string url) 
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JObject, HttpStatusCode) PostData(string url, object content)
        {
            var client = new HttpClient();
            var requestContent = new StringContent(
                JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json");
            var response = client.PostAsync(url, requestContent).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        HttpStatusCode PutData(string url, object content)
        {
            var client = new HttpClient();
            var response = client.PutAsync(
                url,
                new StringContent(
                    JsonConvert.SerializeObject(content),
                    Encoding.UTF8,
                    "application/json")).Result;
            return response.StatusCode;
        }

        HttpStatusCode DeleteData(string url)
        {
            var client = new HttpClient();
            var response = client.DeleteAsync(url).Result;
            return response.StatusCode;
        }

    }
}
