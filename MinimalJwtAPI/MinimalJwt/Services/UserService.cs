using MinimalJwt.Models;
using MinimalJwt.Repositories;

namespace MinimalJwt.Services
{
    public class UserService : IUserService
    {
        public User Get(UserLogin userLogin)
        {
            User user = UserRepository.Users
                .FirstOrDefault(u => u.Username
                    .Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) && u.Password
                    .Equals(userLogin.Password));

            return user;
        }
    }
}
