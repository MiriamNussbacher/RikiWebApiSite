
using Entities;
using Repositories;
using Zxcvbn;

namespace Services
{
    public class UsersService
    {
        UsersRepository usersRepository=new UsersRepository();
        public User getUsersById(int id)
        {
            return usersRepository.getUsersById(id); 
        }


         public User getUserByEmailAndPassword(User userFromBody)
        {
            return usersRepository.getUserByEmailAndPassword(userFromBody);
        }

        public User createUser(User user)

        {
            var resultPassword = Zxcvbn.Core.EvaluatePassword(user.Password);
            if (resultPassword.Score< 2)
            {
                return null; 
            }
            return usersRepository.createUser(user);
        }

        public User updateUser(int id, User userToUpdate)
        {
            return usersRepository.updateUser(id, userToUpdate);

        }

    }
}