using Fasade.DTO;
using Fasade.Interfaces.Repository;
using Repository.Database;

namespace Repository
{
    public class CityRepository : RepositoryBase<CityDTO>, ICityRepository
    {
        public CityRepository(TBCDbContext dbContext) : base(dbContext) { }
    }
}
