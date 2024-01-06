using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUser
    {
        Task<List<User>> GetAll();
        Task<User> Add(User user);
        Task<User> Update(User user);
        Task Delete(int id);
    }
}
