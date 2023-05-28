using Fasade.DTO;
using System.Linq.Expressions;

namespace Fasade.Interfaces.Repository
{
    public interface IPersonRepository : IRepositoryBase<PersonDTO>
    {
        IQueryable<PersonDTO> Search(Expression<Func<PersonDTO, bool>> predicate);
        void UploadOrChangeImage(int personId, string image);
    }
}
