using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class DataService
    {
        public List<Post> GetPosts()
        {
            using (var db = new SOVAContext())

            
                return db.Posts.ToList();
        }

        /*public List<Question> GetQuestions()
        {
            using (var db = new SOVAContext())

                return db.Questions.Include(x => x.Post).ToList();
        }*/
    }
}
