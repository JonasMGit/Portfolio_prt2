using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    [Route("api/mark")]
    [ApiController]
    public class MarksController : Controller
    {
        private readonly IDataService _dataService;
        public MarksController(DataService dataService)
        {
            _dataService = dataService;
        }


        [HttpPost]
        public IActionResult PostMarks([FromBody]Mark mark)
        {

            _dataService.CreateMarking(mark.PostId, mark.UserId);

            return Created($"api/mark/{mark}", mark);

        }


        [HttpDelete("id")]
        public IActionResult DeleteMarks(int userid, int postid)
        {
            var del = _dataService.DeleteMarking(userid, postid);

            if (del==false) return NotFound();
            return Ok(del);
        }
            
           
          
    }

    


}