using Tryitter.API.Data;

namespace Tryitter.API.Contracts
{
    public interface ITweetRepository : IGenericRepository<Tweet>
    {
        Task<Tweet> GetById(int id);
        Task<List<Tweet>> GetByUser(int userId);
    }
}
