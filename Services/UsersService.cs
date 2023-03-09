
using Entities;
using Repositories;
using Zxcvbn;

namespace Services
{
    public class UsersService
    {
        UsersRepository usersRepository=new UsersRepository();
        public async Task<User> getUsersById(int id)
        {
            return await usersRepository.getUsersById(id); 
        }


         public async Task<User> getUserByEmailAndPassword(User userFromBody)
        {
            return await usersRepository.getUserByEmailAndPassword(userFromBody);
        }

        public async Task<User> createUser(User user)

        {
            var resultPassword = Zxcvbn.Core.EvaluatePassword(user.Password);
            if (resultPassword.Score< 2)
            {
                return null; 
            }
            return await usersRepository.createUser(user);
        }

        public async Task<User> updateUser(int id, User userToUpdate)
        {
            return await usersRepository.updateUser(id, userToUpdate);

        }

    }
}