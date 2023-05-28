using Fasade.Interfaces.Repository;
using Repository.Database;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TBCDbContext _context;

        private Lazy<IPersonRepository> _personRepository;
        private Lazy<ICityRepository> _cityRepository;
        private Lazy<IRelatedPersonRepository> _relatedPersonRepository;
        private Lazy<IUserRepository> _userRepository;


        public UnitOfWork(TBCDbContext context)
        {
            _context = context;
            CreateLazyInstances();
        }

        public IPersonRepository PersonRepository => _personRepository.Value;
        public ICityRepository CityRepository => _cityRepository.Value;
        public IRelatedPersonRepository RatedPersonRepository => _relatedPersonRepository.Value;
        public IUserRepository UserRepository => _userRepository.Value;

        public void BeginTransaction() =>
            _context.Database.BeginTransaction();

        public void CommitTransaction() =>
            _context.Database.CommitTransaction();

        public void RollbackTransaction() =>
            _context.Database.RollbackTransaction();

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private void CreateLazyInstances()
        {
            _personRepository = new Lazy<IPersonRepository>(() => new PersonRepository(_context));
            _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(_context));
            _relatedPersonRepository = new Lazy<IRelatedPersonRepository>(() => new RelatedPersonRepository(_context));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
        }
    }
}