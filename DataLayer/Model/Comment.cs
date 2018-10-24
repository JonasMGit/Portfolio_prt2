using System;
using System.Collections.Generic;
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

        public Author Author { get; set; }
        public Post Post { get; set; }
    }
}
