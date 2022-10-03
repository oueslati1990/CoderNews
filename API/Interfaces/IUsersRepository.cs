using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<AppUser>> ListUsersAsync();
        Task<AppUser> GetUserAsync(int id);
    }
}
