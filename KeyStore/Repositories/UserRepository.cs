using KeyStore.Data;
using KeyStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KeyStore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KeyStoreDbContext _context;
        public UserRepository(KeyStoreDbContext context)
        {
            _context = context;
        }
        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var keys = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (keys != null)
            {
                _context.Users.Remove(keys);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetSingleUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(k => k.Id == id);
        }

        public Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
