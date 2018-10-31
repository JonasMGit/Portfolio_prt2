using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [Route("api/answers")]
    [ApiController]
    public class AnswersController : Controller
    {
        DataService _dataService;
        public AnswersController(DataService dataService)
        {
            _dataService = dataService;
        }
        [HttpGet]
        public IActionResult GetAnswers()
        {
            var answers = _dataService.GetAnswers();
            return Ok(answers);
        }
        [HttpGet("{id}")]
        public IActionResult GetAnswer(int id)
        {
            var answer = _dataService.GetAnswer(id);
            if (answer == null) return NotFound();
            return Ok(answer);

        }
    }
}