using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BowlersBaby.Models;

namespace BowlersBaby.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRespository repo { get; set; }

        public HomeController(IBowlersRespository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            var bowlers = repo.Bowlers
                .ToList();

            return View(bowlers);
        }

    }
}
