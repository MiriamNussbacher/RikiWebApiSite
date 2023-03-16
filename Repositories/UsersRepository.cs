using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Repositories
{
    public class UsersRepository : IUsersRepository
    {
        ShopDbContext _shopDbContext; //readonly? 
        public UsersRepository(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }



        //string filePath = "M:/webApi/ShopSite/Repositories/users.txt";
        //"E:/web/update-web/ShopSite/Repositories/users.txt";
        public async Task<User> getUsersById(int id)
        {
            User user = await _shopDbContext.Users.FindAsync(id);
            return user;
            //using (StreamReader reader = System.IO.File.OpenText(filePath))
            //{
            //    string? currentUserInFile;
            //    while ((currentUserInFile = await reader.ReadLineAsync()) != null)
            //    {
            //        User user = JsonSerializer.Deserialize<User>(currentUserInFile);
            //        if (user.UserId == id)
            //            return user;
            //    }
            //}
            //return null;

        }




        public async Task<User> getUserByEmailAndPassword(User userFromBody)
        {
            List<User> users = await _shopDbContext.Users.Where(user =>
            userFromBody.Email == user.Email && userFromBody.Password == user.Password).ToListAsync();
            if (users.Count() > 0)
                return users[0];
            return null;

            //"M:\\webApi\\ShopSite\\Repositories\\
            //    using (StreamReader reader = System.IO.File.OpenText(filePath))
            //    {
            //        string? currentUserInFile;
            //        while ((currentUserInFile = await reader.ReadLineAsync()) != null)
            //        {
            //            User user = JsonSerializer.Deserialize<User>(currentUserInFile);
            //            if (user.Email == userFromBody.Email && user.Password == userFromBody.Password)
            //                return user;
            //        }
            //    }
            //    return null;

        }


        public async Task<User> createUser(User user)
        {

            await _shopDbContext.AddAsync(user);
            await _shopDbContext.SaveChangesAsync();
            return user;

            //    int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            //user.UserId = numberOfUsers + 1;
            //string userJson = JsonSerializer.Serialize(user);
            //await System.IO.File.AppendAllTextAsync(filePath, userJson + Environment.NewLine);
            //return user;
        }


        public async Task<User> updateUser(int id, User userToUpdate)
        {

             _shopDbContext.Users.Update(userToUpdate);
            await _shopDbContext.SaveChangesAsync();
            return userToUpdate;




            //        string textToReplace = string.Empty;
            //    using (StreamReader reader = System.IO.File.OpenText(filePath))
            //    {
            //        string currentUserInFile;
            //        while ((currentUserInFile = await reader.ReadLineAsync()) != null)
            //        {

            //            User user = JsonSerializer.Deserialize<User>(currentUserInFile);
            //            if (user.UserId == id)
            //                textToReplace = currentUserInFile;
            //        }
            //    }

            //    if (textToReplace != string.Empty)
            //    {
            //        string text = await System.IO.File.ReadAllTextAsync(filePath);
            //        text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
            //        await System.IO.File.WriteAllTextAsync(filePath, text);
            //        return userToUpdate;
            //    }

            //    return null;
            //}



        }
    }
}
