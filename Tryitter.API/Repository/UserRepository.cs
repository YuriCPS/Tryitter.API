using Microsoft.EntityFrameworkCore;
using Tryitter.API.Contracts;
using Tryitter.API.Data;

namespace Tryitter.API.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly TryitterDbContext _context;

        public UserRepository(TryitterDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Include(q => q.Module).FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<User> GetByUserName(string userName)
        {
            return await _context.Users.Include(q => q.Module).FirstOrDefaultAsync(q => q.UserName == userName);
        }
    }
}
