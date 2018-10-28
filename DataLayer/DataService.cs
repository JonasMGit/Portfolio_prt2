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

        public List<Post> GetQuestions()
        {
            using (var db = new SOVAContext())
            {
                var questions = db.Posts.
                    Where(x => x.ParentId == null);
                return questions.ToList();
            }
        }

        public Post GetQuestion(int id)
        {
            using (var db = new SOVAContext())
            {
                var question = db.Posts
                    .Where(x => x.ParentId == null)
                    .FirstOrDefault(x => x.PostId == id);
                return question;
            }
        }

        public List<Comment> GetQuestionComments(int id)
        {
            using (var db = new SOVAContext())
            {
               
                var commentsToQuestion = db.Comments
                      .Where(x => x.Parent == id)
                      .ToList();
                return commentsToQuestion;
            }
        }
        /*
        public Post MasterFunction (int id)
        {
            using (var db = new SOVAContext())
            {

                
            }
        }*/

        public List<Post> GetQuestionsByString(string title)
        {
            using (var db = new SOVAContext())
            {
                
                var question = db.Posts.Where(x => x.ParentId == null &&
                (x.Body.ToLower().Contains(title.ToLower()) || x.Title.ToLower().Contains(title.ToLower())));
                return question.ToList();

            }
        }
        public List<Post> GetAnswers()
        {
            using (var db = new SOVAContext())
            {
                var answers = db.Posts
                    .Where(x => x.ParentId != null);
                return answers.ToList();
            }
        }

        public Post GetAnswer(int id)
        {
            using (var db = new SOVAContext())
            {
                var answer = db.Posts
                    .Where(x => x.ParentId != null)
                    .FirstOrDefault(x => x.PostId == id);

                return answer;
            }
        }
            
    }
}
