using Fasade.DTO;
using Fasade.Interfaces.Repository;
using Repository.Database;

namespace Repository
{
    public class RelatedPersonRepository : RepositoryBase<RelatedPersonDTO>, IRelatedPersonRepository
    {
        public RelatedPersonRepository(TBCDbContext dbContext) : base(dbContext) { }
    }
}
