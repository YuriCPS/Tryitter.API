using Tryitter.API.Data;

namespace Tryitter.API.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetById(int id);
        Task<User> GetByUserName(string userName);
        Task<User> GetByEmail(string email);
    }
}
