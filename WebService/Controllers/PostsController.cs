using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;

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

        [HttpGet]
        public IActionResult GetPosts()
        {
            var data = _dataService.GetPosts();

            return Ok(data);
        }

        [HttpGet("questions")]
        public IActionResult GetQuestions()
        {
            var questions = _dataService.GetQuestions();
            return Ok(questions);
        }

        [HttpGet("answers")]
        public IActionResult GetAnswers()
        {
            var answers = _dataService.GetAnswers();
            return Ok(answers);
        }

        /* [Route("api/questions")]
         [HttpGet]
         public IActionResult GetQuestions()
         {
             var question = _dataService.GetQuestions();
             return Ok(question);
         }*/
    }
}
