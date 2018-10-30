using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Model
{
    public class Annotations
    {
       
        public string Body { get; set; }
        [ForeignKey("Post")]
        public int ParentId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        public Post Post { get; set; }
        
    }
}
