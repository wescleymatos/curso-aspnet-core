using Microsoft.AspNetCore.Mvc;
using MvcEF.Data;
using MvcEF.Domain;

namespace MvcEF.Controllers
{
    public class CategoryController : Controller
    {
        private readonly EFContext _context;

        public CategoryController(EFContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}