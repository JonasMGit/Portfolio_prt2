using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Http;

namespace WebService.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : Controller
    {
        DataService _dataService;
        public PostsController(DataService dataService)
        {
            _dataService = dataService;
        }
        //-----------------------------Questions and Answers ----------------------//
        [HttpGet]
        public IActionResult GetPosts()
        {
            var data = _dataService.GetPosts();

            return Ok(data);
        }
       /* [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            var post = _dataService.GetPost(id);
                if (post == null) return NotFound();
            return Ok(post);
        }*/

        [HttpGet("questions")]
        public IActionResult GetQuestions()
        {
            var questions = _dataService.GetQuestions();
            return Ok(questions);
        }

        [HttpGet("questions/{id}")]
        public IActionResult GetQuestion(int id)
        {
            var question = _dataService.GetQuestion(id);
                if (question == null) return NotFound();
            return Ok(question);
        }

        [HttpGet("questions/name/{name}")]
        public IActionResult GetQuestionByName(string name)
        {
            var question = _dataService.GetQuestionsByString(name);
            if (question.Count == 0) return NotFound();
             return Ok(question);
            

        }

        [HttpGet("answers")]
        public IActionResult GetAnswers()
        {
            var answers = _dataService.GetAnswers();
            return Ok(answers);
        }

       [HttpGet("answers/{id}")]
       public IActionResult GetAnswer(int id)
        {
            var answer = _dataService.GetAnswer(id);
            if (answer == null) return NotFound();
            return Ok(answer);

        }
    }
}
