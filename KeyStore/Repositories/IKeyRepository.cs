using KeyStore.Models;

namespace KeyStore.Repositories
{
    public interface IKeyRepository
    {
        Task<IEnumerable<Key>> GetAllKeys();
        Task<Key> GetSingleKey(int id);
        Task CreateKey(Key key);
        Task DeleteKey(int id);
        Task UpdateKey(Key key);

    }
}
