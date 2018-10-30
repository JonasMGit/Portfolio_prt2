﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    
   public abstract class Post
    {
       
        public int PostId { get; set; }

        public int PostType { get; set; }
        
       // public int ?ParentId { get; set; }
        
        public int ?AcceptedAnswerId { get; set; }

        public int Score { get; set; }
       
        public DateTime CreationDate { get; set; }
       
        public string Body { get; set; }

        public DateTime ?ClosedDate { get; set; }

        //public string Title { get; set; }

        //this is foriegn key to author 
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        //I removed the posttype column as it is not needed

        public List<PostTag> PostTags { get; set; }

       // [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        //henrik said this should go to question
        public List<Comment> Comments { get; set; }




        
    }
}
