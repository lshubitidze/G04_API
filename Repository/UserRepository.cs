using Fasade.DTO;
using Fasade.Interfaces.Repository;
using Repository.Database;

namespace Repository
{
    public class UserRepository : RepositoryBase<UserDTO>, IUserRepository
    {
        private readonly TBCDbContext _dbContext;

        public UserRepository(TBCDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public UserDTO Login(string username, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserName.Equals(username));

            if (user == default || !ValidPassword(password, user.Password))
                throw new ArgumentException("Username or password is incorrect");

            return user;
        }

        public override UserDTO Insert(UserDTO model)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserName.Equals(model.UserName));

            if (user != default)
                throw new Exception("User already exists");

            model.Password = HashPassword(model.Password);

            return base.Insert(model);
        }

        private static string HashPassword(string password) =>
            BCrypt.Net.BCrypt.HashPassword(password);

        private static bool ValidPassword(string newPassword, string oldPassword) =>
            BCrypt.Net.BCrypt.Verify(newPassword, oldPassword);
    }
}
