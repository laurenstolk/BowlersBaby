using System;
using System.Linq;
using BowlersBaby.Models;

namespace BowlersBaby.Models.ViewModels
{
    public class BowlersViewModel
    {
        public IQueryable<Bowler> Bowlers { get; set; }
        public IQueryable<Team> Teams { get; set; }
    }
}