using KeyStore.Data;
using KeyStore.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyStore.Repositories
{
    public class KeyRepository : IKeyRepository
    {
        private readonly KeyStoreDbContext _context;
        public KeyRepository(KeyStoreDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task CreateKey(Key key)
        {
            await _context.Keys.AddAsync(key);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteKey(int id)
        {
            var keys = await _context.Keys.FirstOrDefaultAsync(x => x.Id == id);
            if(keys != null)
            {
                _context.Keys.Remove(keys);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Key>> GetAllKeys()
        {
            var keys =  await _context.Keys.Include(k=> k.User).ToListAsync();
            return keys;
        }

        public async Task<Key> GetSingleKey(int id)
        {
            return await _context.Keys.Include(k=> k.User).FirstOrDefaultAsync(k=>k.Id == id);
        }

        public async Task UpdateKey(Key key)
        {
            _context.Entry(key).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
