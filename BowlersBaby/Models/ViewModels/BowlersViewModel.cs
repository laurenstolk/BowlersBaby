using System;
using System.Linq;

namespace BowlersBaby.Models.ViewModels
{
    public class BowlersViewModel
    {
        public IQueryable<Bowler> Bowlers { get; set; }
        public IQueryable<Team> Teams { get; set; }
    }
}