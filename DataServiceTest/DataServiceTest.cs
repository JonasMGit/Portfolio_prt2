using DataLayer;
using System;
using System.Linq;
using Xunit;


namespace DataServiceTest
{
    public class DataServiceTest
    {
        

        //post
       /* [Fact]
        public void GetallPost_withnoargument_Returnsallposts()
        {
            var service = new DataService();
            var posts = service.GetPosts();
            Assert.Equal(13629, posts.Count);
            Assert.Equal("Hide Start Menu and Start Button in VB.NET", posts.First().Title);
        }*/

       
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
            //Assert.Null(posts.ParentId);
            Assert.Equal(myDate,posts.CreationDate);
        }
        //GetQuestion_ByString
        [Fact]
        public void GetQuestions_ByString_ReturnsList()
        {
            var service = new DataService();
            var questions = service.GetQuestionsByString("eg");
            Assert.Equal(224, questions.Count);
            Assert.NotNull(questions.First().AuthorId);
            Assert.Equal("How can a bot get the contents of subsequent pages in a category listing in WordPress?", questions.First().Title);
        }

      /* [Fact]
        public void GetTags_ByPosts()
        {
            var service = new DataService();
            var tag = service.GetPost(19329707);
            Assert.Equal(5, tag.PostTags.Count());
        }       */ 
     
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
        public void GetAnswer_WithComments()
        {
            var service = new DataService();
            var answers = service.GetAnswer(408396);
            Assert.Equal(25, answers.Comments.Count());
        }

      /*  [Fact]
        public void GetAnswers_ByValidId()
        {
            var service = new DataService();
            var posts = service.GetAnswer(3126560);
            Assert.Equal(2180354, posts.ParentId);
            Assert.Equal(1, posts.Score);
        }*/

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
        
            var users = service.createUser("MOther", "father").Id;

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

            service.DeleteUser(newUser.Id);
        }
        [Fact]
        public void UpdateUser_InvalidId_ReturnsFalse()
        {
            var service = new DataService();
            var userr = service.UpdateUser(-10,"updatedusername","updatedpassword");
            Assert.False(userr);
        }

        [Fact]
        public void SaveUserSearchHistory()
        {
            var service = new DataService();
            var newUser = service.createUser("History","Saved");
            var newSearch = service.SaveSearch("Hide",newUser.Id);
            Assert.Equal("Hide", newSearch.Search);
        }


    } //closening the DataService class

} //closing the namespace DataServiceTest
