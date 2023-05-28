using Fasade.DTO;
using Fasade.Interfaces.Repository;
using Fasade.Interfaces.Service;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = _unitOfWork.UserRepository;
        }

        public void Delete(UserDTO model)
        {
            _userRepository.Delete(model);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public void Dispose() => _unitOfWork.Dispose();

        public UserDTO GetById(int id) => _userRepository.GetById(id);

        public UserDTO Insert(UserDTO model)
        {
            _userRepository.Insert(model);
            _unitOfWork.SaveChanges();
            return model;
        }

        public UserDTO Login(string username, string password) =>
            _userRepository.Login(username, password);

        public void Register(UserDTO user)
        {
            Insert(user);
        }

        public void Update(UserDTO model) => _userRepository.Update(model);
    }
}
