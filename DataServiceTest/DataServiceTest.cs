using DataLayer;
using System;
using System.Linq;
using Xunit;


namespace DataServiceTest
{
    public class DataServiceTest
    {
        

        //post
        [Fact]
        public void GetallPost_withnoargument_Returnsallposts()
        {
            var service = new DataService();
            var posts = service.GetPosts();
            Assert.Equal(13629, posts.Count);
            Assert.Equal("Hide Start Menu and Start Button in VB.NET", posts.First().Title);
        }

       
        //questions
        [Fact]
        public void GetQuestions()
        {
            var service = new DataService();
            var posts = service.GetQuestions();
            Assert.Equal(2237, posts.Count);
            Assert.Equal("Hide Start Menu and Start Button in VB.NET", posts.First().Title);

        }

        [Fact]
        public void GetQuestions_ByValidId()
        {
            var service = new DataService();
            var posts = service.GetQuestion(13649012);
            DateTime myDate = DateTime.ParseExact("2012-11-30 16:21:10", "yyyy-MM-dd HH:mm:ss",
                System.Globalization.CultureInfo.InvariantCulture);
            Assert.Null(posts.ParentId);
            Assert.Equal(myDate,posts.CreationDate);
        }
        //GetQuestion_ByString
        [Fact]
        public void GetQuestions_ByString_ReturnsList()
        {
            var service = new DataService();
            var questions = service.GetQuestionsByString("hide");
            Assert.Equal(30, questions.Count);
            Assert.Equal("Hide Start Menu and Start Button in VB.NET", questions.First().Title);
            Assert.Equal("<p>I'm setting my console full screen but I also want to hide the task bar and the start button in VB.NET using Visual Studio 2010</p>&#xA;&#xA;<p>Thanks</p>&#xA;", questions.First().Body);
        }
        
     
        //Answers
        [Fact]
        public void GetAnswers()
        {
            var service = new DataService();
            var posts = service.GetAnswers();
            Assert.Equal(11392, posts.Count);
            //Assert.Equal("Hide Start Menu and Start Button in VB.NET", posts.First().Title);
        }

        [Fact]
        public void GetAnswers_ByValidId()
        {
            var service = new DataService();
            var posts = service.GetAnswer(3126560);
            Assert.Equal(2180354, posts.ParentId);
            Assert.Equal(1, posts.Score);
        }

        //comments

        [Fact]
        public void GetCommentsToAQuestion()
        {
            var service = new DataService();
            var comments = service.GetQuestionComments(13649012);
            DateTime myDate = DateTime.ParseExact("2012-11-30 16:53:35", "yyyy-MM-dd HH:mm:ss",
    System.Globalization.CultureInfo.InvariantCulture);
            Assert.Equal(myDate,comments.FirstOrDefault().CreationDate);
        }

        [Fact]
        public void CreateNewUserTest()
        {
            var service = new DataService();
            var userNew = service.createUser("Henning", "Flemming");
           
        }

        [Fact]
        public void DeleteUser()
        {
            var service = new DataService();
            //var users = service.getUsers().ToList();
            var users = service.createUser("Mother", "facker").Id;
            
            //var user = users.LastOrDefault().Id;
                //FirstOrDefault().Id;

            var deluser = service.DeleteUser(users);
            Assert.True(deluser);

        }

        [Fact]
        public void UpdateUser_userName_Password_WithValidId()
        {
            var service = new DataService();
            var newUser = service.createUser("userUpdateTest", "testertest");
            

            var user = service.UpdateUser(newUser.Id,"updatedusername","updatedpassword");
            Assert.True(user);

            newUser= service.GetUser(newUser.Id);
            Assert.Equal("updatedusername", newUser.UserName);
            Assert.Equal("updatedpassword", newUser.Password);

        }
        [Fact]
        public void UpdateUser_InvalidId_ReturnsFalse()
        {
            var service = new DataService();
            var userr = service.UpdateUser(-10,"updatedusername","updatedpassword");
            Assert.False(userr);
        }




        /*
           [Fact]
        public void UpdateCategory_NewNameAndDescription_UpdateWithNewValues()
        {
            var service = new DataService();
            var category = service.CreateCategory("TestingUpdate", "UpdateCategory_NewNameAndDescription_UpdateWithNewValues");

            var result = service.UpdateCategory(category.Id, "UpdatedName", "UpdatedDescription");
            Assert.True(result);

            category = service.GetCategory(category.Id);

            Assert.Equal("UpdatedName", category.Name);
            Assert.Equal("UpdatedDescription", category.Description);

            // cleanup
            service.DeleteCategory(category.Id);
        }
        */

    }

}
