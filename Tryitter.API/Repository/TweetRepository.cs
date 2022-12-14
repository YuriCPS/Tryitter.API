using Microsoft.EntityFrameworkCore;
using Tryitter.API.Contracts;
using Tryitter.API.Data;

namespace Tryitter.API.Repository
{
    public class TweetRepository : GenericRepository<Tweet>, ITweetRepository
    {
        private readonly TryitterDbContext _context;

        public TweetRepository(TryitterDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tweet> GetById(int id)
        {
            return await _context.Tweets.Include(q => q.User).FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<List<Tweet>> GetByUser(int userId)
        {
            return await _context.Tweets.Include(q => q.User).Where(q => q.UserId == userId).ToListAsync();
        }
    }
}
