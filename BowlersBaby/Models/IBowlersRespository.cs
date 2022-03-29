using System;
using System.Linq;

namespace BowlersBaby.Models
{
    public interface IBowlersRespository
    {
        IQueryable<Bowler> Bowlers { get; }
    }
}
