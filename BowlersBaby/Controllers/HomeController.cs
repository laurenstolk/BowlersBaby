using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BowlersBaby.Models;
using BowlersBaby.Models.ViewModels;

namespace BowlersBaby.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRespository repo { get; set; }
        private BowlersDbContext context { get; set; }

        public HomeController(IBowlersRespository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string teamname)
        {
            //var x = new BowlersViewModel
            //{
            //    Bowlers = repo.Bowlers
            //        .Where(x => x.TeamID == team)
            //};

            //ViewBag.Teams = context.Teams.ToList();

            ViewBag.teamname = teamname;

            var x = repo.Bowlers
                .Where(x => x.Team.TeamName == teamname || teamname == null)
                .Include(x => x.Team)
                .ToList();

            return View(x);
        }

        [HttpGet]
        public IActionResult AddBowler()
        {
            //ViewBag.Teams = repo.Teams
            //    .Include(x => x.TeamName);

            Bowler bowler = new Bowler();

            ViewBag.Teams = repo.Teams.ToList();
            ViewBag.Bowler = repo.Bowlers.ToList();

            return View(bowler);
        }

        [HttpPost]
        public IActionResult AddBowler(Bowler b)
        {
            if (ModelState.IsValid)
            {
                b.BowlerID = (repo.Bowlers.Max(b => b.BowlerID)) + 1;
                repo.AddBowler(b);
                return RedirectToAction("Index");

                //context.Add(b);
                //context.SaveChanges();
                //return View("Confirmation", b);
            }
            else
            {
                ViewBag.Teams = repo.Teams.ToList();
                ViewBag.Bowler = repo.Bowlers.ToList();
                return View(b);
            }
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Teams = repo.Teams.ToList();

            var bowler = repo.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("AddBowler", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            repo.EditBowler(b);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(Bowler b)
        {
            repo.DeleteBowler(b);
            return RedirectToAction("Index");
        }

    }
}
