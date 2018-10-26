using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
       /* [HttpGet]
        public IActionResult GetQuestions()
        {
            var question = _dataService.GetQuestions();
            return Ok(question);
        }*/
    }
}
