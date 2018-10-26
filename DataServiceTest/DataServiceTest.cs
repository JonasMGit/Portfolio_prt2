using DataLayer;
using System;
using System.Linq;
using Xunit;


namespace DataServiceTest
{
    public class DataServiceTest
    {
        [Fact]
        public void GetallPost_withnoargument_Returnsallposts()
        {
            var service = new DataService();
            var posts = service.GetPosts();
            Assert.Equal(13629, posts.Count);
            Assert.Equal("Hide Start Menu and Start Button in VB.NET", posts.First().Title);
        }
    }

}
