using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DataLayer.Model
{
    public class User
    {
        public new int Id { get; set; }
        public new string UserName{ get; set; }
        public DateTime CreationDate { get; set; }
        public string Password { get; set; }
        public List<SearchHistories> SearchHistory{ get; set; }
        public List<Mark> Marks { get; set; }
        public List<Annotations> Annotations { get; set; }

    }
}
