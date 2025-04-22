using Microsoft.EntityFrameworkCore;
using MvcStartApp.Context;
using MvcStartApp.Models.Db;

namespace MvcStartApp.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            var entry = _context.Entry(user);
            if (entry.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Request>> GetRequests()
        {
            return await _context.Requests
                .OrderByDescending(r => r.Date)
                .ToListAsync();
        }

        public async Task SaveRequest(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
            return await _context.Users.ToArrayAsync();
        }
    }
}
