using System;
using System.Linq;

namespace BowlersBaby.Models
{
    public interface IBowlersRespository
    {
        IQueryable<Bowler> Bowlers { get; }
        IQueryable<Team> Teams { get; }

        public void AddBowler(Bowler b);
        public void EditBowler(Bowler b);
        public void DeleteBowler(Bowler b);
    }
}
