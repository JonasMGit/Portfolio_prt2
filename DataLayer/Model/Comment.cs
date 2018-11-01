using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime CreationDate { get; set; }
        public string Body { get; set; }
        public int AuthorId { get; set; }
       
        public Author Author { get; set; }
        
        public int PostId { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }
       


    }
}
