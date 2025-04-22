using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Repository;

namespace MvcStartApp_.Controllers
{
    [Route("logs")]
    public class LogsController : Controller
    {
        private readonly IBlogRepository _repo;

        public LogsController(IBlogRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var requests = await _repo.GetRequests();
            return View(requests); // Views/Logs/Index.cshtml
        }
    }
}
