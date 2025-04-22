using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcStartApp.Context;
using MvcStartApp.Models.Db;
using MvcStartApp.Repository;

namespace MvcStartApp_.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repo;
        private readonly BlogContext _context;

        public UsersController(IBlogRepository repo, BlogContext context)
        {
            _repo = repo;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _repo.GetUsers();
            return View(authors);
        }


        // GET: /Users/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View(); // Покажет форму
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            await _repo.AddUser(user);
            return View(user);
        }
    }
}
