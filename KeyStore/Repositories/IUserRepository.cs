using KeyStore.Models;

namespace KeyStore.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<User> GetSingleUser(int id);
        Task CreateUser(User user);
        Task DeleteUser(int id);
        Task UpdateUser(User user);
    }
}
