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
        public IActionResult Update(int villaId)
        {
            
            var villaInfo = _context.Villas.FirstOrDefault(v => v.Id == villaId);
            if(villaInfo is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaInfo);
        }
        [HttpPost]
        public IActionResult Update(Room obj)
        {
            if(obj.Name==obj.Description)
            {
                ModelState.AddModelError("Name", "Name and Description can't be same");
            }
            if(ModelState.IsValid)
            {
                _context.Villas.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(obj);
        }
        [HttpGet]
        public IActionResult Delete(int villaId)
        {
            var villaObj = _context.Villas.FirstOrDefault(v => v.Id == villaId);
            if(villaObj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaObj);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var villaObj = _context.Villas.FirstOrDefault(v => v.Id == id);
            if(villaObj is null)
            {
                return RedirectToAction("Error", "Home");
            }
           _context.Villas.Remove(villaObj);
           _context.SaveChanges();
            return RedirectToAction("Index");
          

        }

    }
}
