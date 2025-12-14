using Microsoft.AspNetCore.Mvc;
using Villa.Domain.Entities;
using Villa.Infrastructure.Data;
using Villa.Web.Helpers;
using Villa.Web.ViewModels;

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
        public IActionResult Create(CreateVillaVM obj)
        {
            VillaValidator.Validate(obj.Name, obj.Description, ModelState);
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Villa Creation Failed";
                return View(obj);
            }
            var villa = new Room()
            {
                Name = obj.Name,
                Description = obj.Description,
                Price = obj.Price,
                Sqft = obj.Sqft,
                Occupancy = obj.Occupancy,
                ImageUrl = obj.ImageUrl
            };
            _context.Villas.Add(villa);
            _context.SaveChanges();
            TempData["Success"] = "Villa Created Successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Update(int villaId)
        {

            var villaInfo = _context.Villas.FirstOrDefault(v => v.Id == villaId);
            if (villaInfo is null)
            {
                TempData["Error"] = "Villa Not Found";

                return RedirectToAction("Error", "Home");
            }
            return View(villaInfo);
        }
        [HttpPost]
        public IActionResult Update(Room obj)
        {
            VillaValidator.Validate(obj.Name,obj.Description,ModelState);
            if (ModelState.IsValid)
            {
                _context.Villas.Update(obj);
                _context.SaveChanges();
                TempData["Success"] = "Villa Updated Successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Villa Updated Failed";
            return View(obj);
        }
        [HttpGet]
        public IActionResult Delete(int villaId)
        {
            var villaObj = _context.Villas.FirstOrDefault(v => v.Id == villaId);
            if (villaObj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaObj);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            var villaObj = _context.Villas.FirstOrDefault(v => v.Id == id);
            if (villaObj is null)
            {
                TempData["Error"] = "Villa Not found";
                return RedirectToAction("Error", "Home");
            }
            _context.Villas.Remove(villaObj);
            _context.SaveChanges();
            TempData["Success"] = "Villa Delted Successfully";
            return RedirectToAction("Index");
        }

    }
}
