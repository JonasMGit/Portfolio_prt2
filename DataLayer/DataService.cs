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

        //------------------------Questions and answers----------------------------
        public List<Post> GetPosts()
        {
            using (var db = new SOVAContext())


                return db.Posts.ToList();
        }
        //Full post including comments and tags
        //Get post by comment parentid. Only way we can find that gets question 
        //with comment and posttags
        public Comment GetPost(int id)
        {
            using (var db = new SOVAContext())
            {
                var fullPost = db.Comments.Include(x => x.Post)
                    .ThenInclude(x => x.PostTags)
                    .FirstOrDefault(x => x.Parent == id);
                return fullPost;
            }
        }
        /*public List<Comment> GetPost(int id)
        {
            using (var db = new SOVAContext())
            {
                var fullPost = db.Comments.Include(x => x.Post)
                    .ThenInclude(x => x.PostTags)
                    .Where(x => x.Parent == id);
                    //.FirstOrDefault(x => x.Parent == id);
                return fullPost.ToList();
            }
        }*/

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
                    .FirstOrDefault(x => x.Id == id);
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
                    .Include(x => x.Comments)
                    .Where(x => x.ParentId != null)// && x.Id == id);
                    .FirstOrDefault(x => x.Id == id);

                return answer;
            }
        }
            
    }
}
