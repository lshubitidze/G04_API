using Fasade.DTO;

namespace Fasade.Interfaces.Service
{
    public interface IUserService : IQueryService<UserDTO>, ICommandService<UserDTO>
    {
        UserDTO Login(string username, string password);
        void Register(UserDTO user);
    }
}
