using Entities;

namespace Repositories
{
    public interface IUsersRepository
    {
        Task<User> createUser(User user);
        Task<User> getUserByEmailAndPassword(User userFromBody);
        Task<User> getUsersById(int id);
        Task<User> updateUser(int id, User userToUpdate);
    }
}