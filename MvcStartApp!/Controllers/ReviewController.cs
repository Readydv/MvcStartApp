using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Mvc;
using MvcStartApp_.Models;

namespace MvcStartApp_.Controllers
{
    public class ReviewController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Review review)
        {
            return StatusCode(200, $"{review.From}, спасибо за отзыв!");
        }
    }
}
