using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Model
{
    public class PostTag
    {
        public int PostTagId { get; set; }
        public string Tag { get; set; }

        public Post Post { get; set; }
    }
}
