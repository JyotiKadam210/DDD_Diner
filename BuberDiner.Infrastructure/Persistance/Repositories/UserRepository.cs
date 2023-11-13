using BuberDiner.Application.Common.Interfaces.Persistance;
using BuberDiner.Domain.User;

namespace BuberDiner.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly static List<User> _users = new List<User>();
        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}
