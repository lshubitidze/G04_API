using Fasade.DTO;

namespace Fasade.Interfaces.Service
{
    public interface IRelatedPersonService : ICommandService<RelatedPersonDTO>, IQueryService<RelatedPersonDTO>
    {

    }
}
