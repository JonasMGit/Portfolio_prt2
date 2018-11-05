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
        DataService _dataService;
        public MarksController(DataService dataService)
        {
            _dataService = dataService;
        }
    }
    
    [HttpPost]
    public IActionResult PostMarks()
    {
        _dataService.CreateMarking();
        
        
        
    }

    [HttpDelete]
    public IActionResult DeleteMarks()
    {
        
    }
}