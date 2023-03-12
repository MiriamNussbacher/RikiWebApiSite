
using Entities;
using Repositories;
using Zxcvbn;

namespace Services
{
    public class UsersService : IUsersService
    {
        readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<User> getUsersById(int id)
        {
            return await _usersRepository.getUsersById(id);
        }


        public async Task<User> getUserByEmailAndPassword(User userFromBody)
        {
            return await _usersRepository.getUserByEmailAndPassword(userFromBody);
        }

        public async Task<User> createUser(User user)

        {
            var resultPassword = Zxcvbn.Core.EvaluatePassword(user.Password);
            if (resultPassword.Score < 2)
            {
                return null;
            }
            return await _usersRepository.createUser(user);
        }

        public async Task<User> updateUser(int id, User userToUpdate)
        {
            return await _usersRepository.updateUser(id, userToUpdate);

        }

    }
}