using MvcStartApp.Models.Db;

namespace MvcStartApp.Repository
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
        Task SaveRequest(Request request);
        Task<List<Request>> GetRequests();
    }
}
