using Fasade.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasade.Interfaces.Repository
{
    public interface IUserRepository : IRepositoryBase<UserDTO>
    {
        UserDTO Login(string username, string password);
    }
}
