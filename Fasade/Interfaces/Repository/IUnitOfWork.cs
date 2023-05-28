using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasade.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository PersonRepository { get; }
        ICityRepository CityRepository { get; }
        IRelatedPersonRepository RatedPersonRepository { get; }
        IUserRepository UserRepository { get; }
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void SaveChanges();
    }
}
