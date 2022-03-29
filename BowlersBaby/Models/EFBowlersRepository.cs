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
        public IQueryable<Team> Teams => context.Teams;

        public void AddBowler(Bowler b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void EditBowler(Bowler b)
        {
            context.Update(b);
            context.SaveChanges();
        }

        public void DeleteBowler(Bowler b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
