using Tryitter.API.Data;

namespace Tryitter.API.Contracts
{
    public interface ITweetRepository : IGenericRepository<Tweet>
    {
        Task<Tweet> GetDetails(int id);
    }
}
