using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    
   public class Post
    {
       
        public int PostId { get; set; }
        
        public int Score { get; set; }
       
        public DateTime CreationDate { get; set; }
       
        public string Body { get; set; }
        
        //this is foriegn key to author 
        public int AuthorId { get; set; }
        //I removed the posttype column as it is not needed

        public Question Question { get; set; }

        public Answer Answer { get; set; }

        public Author Author { get; set; }

        public List<Comment> Comments { get; set; }

        public List<PostTag> PostTags { get; set; }
    }
}
