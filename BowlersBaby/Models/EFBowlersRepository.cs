using System;
using System.Linq;

namespace BowlersBaby.Models
{
    public class EFBowlersRepository : IBowlersRespository
    {
        private BowlersDbContext context { get; set; }

        public EFBowlersRepository (BowlersDbContext temp)
        {
            context = temp;
        }

        public IQueryable<Bowler> Bowlers => context.Bowlers;

    }
}
