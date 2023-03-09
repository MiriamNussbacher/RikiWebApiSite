using Entities;
using System.Text.Json;

namespace Repositories
{
    public class UsersRepository
    {
         string filePath = "M:/webApi/ShopSite/Repositories/users.txt";
       
        public async Task<User> getUsersById(int id)
        { 
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        return user; 
                }
            }
            return null;

        }




        public async Task<User> getUserByEmailAndPassword(User userFromBody)
        {
        //"M:\\webApi\\ShopSite\\Repositories\\
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = await reader.ReadLineAsync()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == userFromBody.Email && user.Password == userFromBody.Password)
                        return user;
                }
            }
            return null; 

        }


        public async Task<User> createUser(User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            await System.IO.File.AppendAllTextAsync(filePath, userJson + Environment.NewLine);
            return user; 
        }


        public async Task<User> updateUser(int id,User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile =await reader.ReadLineAsync()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text =await System.IO.File.ReadAllTextAsync(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                await System.IO.File.WriteAllTextAsync(filePath, text);
                return userToUpdate;
            }

            return null; 
        }



    }
}