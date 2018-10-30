using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int Score { get; set; }
        public DateTime CreationDate { get; set; }
        public string Body { get; set; }
        
        public int Parent { get; set; }
        
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        [ForeignKey("Parent")]
        public Post Post { get; set; }

        //public Comment Comment { get; set; }


    }
}
