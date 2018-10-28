using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Model
{
    public class PostTag
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        [ForeignKey("Id")]
        public Post Post { get; set; }
    }
}
