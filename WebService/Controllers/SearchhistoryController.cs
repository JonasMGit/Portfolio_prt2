using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    public class SearchhistoryController : Controller
    {
        DataService _dataService;
        public SearchhistoryController(DataService dataService)
        {
            _dataService = dataService;
        }
    }
}