using Tryitter.API.Data;

namespace Tryitter.API.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetDetails(int id);
    }
}
