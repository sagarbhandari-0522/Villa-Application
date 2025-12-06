using Microsoft.AspNetCore.Mvc;
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
    }
}
