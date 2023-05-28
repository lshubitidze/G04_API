using Fasade.DTO;
using System.Linq.Expressions;

namespace Fasade.Interfaces.Service
{
    public interface IPersonService : IQueryService<PersonDTO>, ICommandService<PersonDTO>
    {
        void UploadOrChangeImage(int personId, string image);
        IQueryable<PersonDTO> Search(Expression<Func<PersonDTO, bool>> predicate);
    }
}
