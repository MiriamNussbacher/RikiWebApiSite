using Entities;

namespace Services
{
    public interface IUsersService
    {
        Task<User> createUser(User user);
        Task<User> getUserByEmailAndPassword(User userFromBody);
        Task<User> getUsersById(int id);
        Task<User> updateUser(int id, User userToUpdate);
    }
}