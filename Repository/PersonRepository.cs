using Fasade.DTO;
using Fasade.Interfaces.Repository;
using Repository.Database;
using System.Linq.Expressions;

namespace Repository
{
    public class PersonRepository : RepositoryBase<PersonDTO>, IPersonRepository
    {
        private readonly TBCDbContext _dbContext;

        public PersonRepository(TBCDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<PersonDTO> Search(Expression<Func<PersonDTO, bool>> predicate) =>
            _dbContext.Set<PersonDTO>().Where(predicate);

        public void UploadOrChangeImage(int personId, string image)
        {
            var person = GetById(personId);
            person.Image = image;
            Update(person);
        }
    }
}
