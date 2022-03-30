using System;
using System.Linq;
using BowlersBaby.Models;
using Microsoft.AspNetCore.Mvc;

namespace BowlersBaby.Components
{
    public class TeamViewComponent : ViewComponent
    {
        private IBowlersRespository repo { get; set; }

        public TeamViewComponent(IBowlersRespository temp)
        {
            repo = temp;
        }

        //Components to get all the teams and send them to the view
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamname"];

            var teams = repo.Teams
                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            return View(teams);
        }
    }
}