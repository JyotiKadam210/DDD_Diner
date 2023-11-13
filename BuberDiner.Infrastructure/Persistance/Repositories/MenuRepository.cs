using BuberDiner.Application.Common.Interfaces.Persistance;
using BuberDiner.Domain.Menu;

namespace BuberDiner.Infrastructure.Persistance.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly BuberDinnerDbContext _dbContext;

        public MenuRepository(BuberDinnerDbContext dbContex)
        {
            _dbContext = dbContex;
        }
        public void Add(Menu menu)
        {
            _dbContext.Add(menu);
            _dbContext.SaveChanges();
        }
    }
}
