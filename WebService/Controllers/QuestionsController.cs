using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : Controller
    {
        DataService _dataService;
        public QuestionsController(DataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IActionResult GetQuestions()
        {
            var questions = _dataService.GetQuestions();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestion(int id)
        {
            var question = _dataService.GetQuestion(id);
            if (question == null) return NotFound();
            return Ok(question);
        }


        [HttpGet("comments/{id}")]
        public IActionResult GetQuestionComment(int id)
        {
            var question = _dataService.GetQuestionComments(id);
            if (question == null) return NotFound();
            return Ok(question);
        }
        [HttpGet("name/{name}")]
        public IActionResult GetQuestionByName(string name, int page = 0, int pageSize = 5)
        {
            var question = _dataService.GetQuestionsByString(name, page, pageSize);
            var numberOfItems = _dataService.GetNumberOfQuestions();

            if (question.Count == 0) return NotFound();
            return Ok(question);


        }
    }
  
}