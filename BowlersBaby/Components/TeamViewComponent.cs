using System;
using System.Linq;
using BowlersBaby.Models;
using Microsoft.AspNetCore.Mvc;

namespace BowlersBaby.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IBowlersRespository repo { get; set; }

        public CategoryViewComponent(IBowlersRespository temp)
        {
            repo = temp;
        }

        //Components to get all the categories and send them to the view
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["team"];

            var teams = repo.Bowlers
                .Select(x => x.Team)
                .Distinct()
                .OrderBy(x => x);

            return View(teams);
        }
    }
}