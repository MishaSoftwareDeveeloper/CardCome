using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Functions
{
    public class UserFunctions: IUser
    {
        public async Task<List<User>> GetAll()
        {
            var users = new List<User>();
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                users = await context.Users.ToListAsync();
            }
            return users;
        }

        public async Task<User> Add(User user)
        {
            using(var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                await context.Users.AddAsync(user);    
                await context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<User> Update(User user)
        {
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                var dbUser = context.Users.Where(u=> u.Id == user.Id).FirstOrDefault();
                if (dbUser != null)
                {
                    dbUser.BirthDate = user.BirthDate;
                    dbUser.PhoneNumber = user.PhoneNumber;
                    dbUser.Name = user.Name;
                    dbUser.Gender = user.Gender;
                    dbUser.Mail = user.Mail;
                    await context.SaveChangesAsync();
                }
                else
                {
                    user = null;
                    throw new Exception("User not found");
                }
            }
            return user;
        }

        public async Task Delete(int id)
        {
            using (var context = new DataBaseContext(DataBaseContext.ops.dbOptions))
            {
                var dbUser = context.Users.Where(u => u.Id == id).FirstOrDefault();
                if (dbUser != null)
                {
                   context.Users.Remove(dbUser);
                   await context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
        }
    }
}
