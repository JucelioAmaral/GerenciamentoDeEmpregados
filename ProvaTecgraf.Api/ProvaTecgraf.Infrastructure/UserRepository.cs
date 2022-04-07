using Microsoft.EntityFrameworkCore;
using ProvaTecgraf.Domain.Identity;
using ProvaTecgraf.Infrastructure.Context;
using ProvaTecgraf.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecgraf.Infrastructure
{
    public class UserRepository : GeralRepository, IUserRepository
    {
        private readonly TecgrafContext _context;

        public UserRepository(TecgrafContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users
                                 .SingleOrDefaultAsync(user => user.UserName == userName.ToLower());
        }
    }
}
