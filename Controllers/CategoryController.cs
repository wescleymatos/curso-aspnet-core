using System.Linq;
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
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            var categoryUpdated = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            categoryUpdated.Name = category.Name;

            _context.Categories.Update(categoryUpdated);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}