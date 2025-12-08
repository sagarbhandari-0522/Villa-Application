using Microsoft.AspNetCore.Mvc;
using Villa.Domain.Entities;
using Villa.Infrastructure.Data;

namespace Villa.Web.Controllers
{
    public class VillaController : Controller
    {
        private ApplicationDbContext _context;
        public VillaController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var villas = _context.Villas.ToList();
            return View(villas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Room obj)
        {
            if(obj.Name==obj.Description)
            {
                ModelState.AddModelError("Name", "Name and Description should not be same");
            }
            if (ModelState.IsValid)
            {
                _context.Villas.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
