using KeyStore.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyStore.Data
{
    public class KeyStoreDbContext:DbContext
    {
        public KeyStoreDbContext(DbContextOptions<KeyStoreDbContext> options) : base(options) { }
        public DbSet<Key> Keys { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
