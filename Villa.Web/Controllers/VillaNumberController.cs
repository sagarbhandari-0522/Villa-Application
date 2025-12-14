using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Villa.Domain.Entities;
using Villa.Infrastructure.Data;
using Villa.Web.ViewModels;

namespace Villa.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly ApplicationDbContext _context;
        public VillaNumberController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var villaNumbers = _context.VillaNumbers.Include(vn => vn.Room).ToList();
            return View(villaNumbers);
        }
        public IActionResult Create()
        {
            var createVillaNumber = new CreateVillaNumberVM();
            createVillaNumber.VillaList = LoadVillaList();
            return View(createVillaNumber);
        }
        [HttpPost]
        public IActionResult Create(CreateVillaNumberVM obj)
        {
            if (_context.VillaNumbers.Any(vn => vn.Villa_Number == obj.VillaNumber.Villa_Number))
            {
                ModelState.AddModelError("VillaNumber.Villa_Number", "Villa Number already used");
            }

            if (ModelState.IsValid)
            {
                _context.VillaNumbers.Add(obj.VillaNumber);
                _context.SaveChanges();
                TempData["Success"] = "Villa Number Created Successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Villa Number Creation Failed";
            obj.VillaList = LoadVillaList();
            return View(obj);
        }
        public IActionResult Update(int id)
        {
            var villaNumber = _context.VillaNumbers.FirstOrDefault(v => v.Villa_Number == id);

            if (villaNumber is null)
            {
                TempData["Error"] = "Villa Number Not Found";

                return RedirectToAction("Error", "Home");
            }
            ViewBag.VillaList = LoadVillaList();
            return View(villaNumber);
        }
        [HttpPost]
        public IActionResult Update(int id, VillaNumber obj)
        {
            if (id != obj.Villa_Number)
            {
                return RedirectToAction("Error", "Home");
            }
            if (ModelState.IsValid)
            {
                _context.VillaNumbers.Update(obj);
                _context.SaveChanges();
                TempData["Success"] = "Villa Number Updated Successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Villa Number Update Failed";
            ViewBag.VillaList = LoadVillaList();
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            var villaNumber = _context.VillaNumbers.Include(v => v.Room).FirstOrDefault(v => v.Villa_Number == id);

            if (villaNumber is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumber);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteVillaNumber(int id)
        {
            var villaNumer = _context.VillaNumbers.FirstOrDefault(v => v.Villa_Number == id);
            if (villaNumer is null)
            {
                TempData["Error"] = "Villa Number not Found";
                return RedirectToAction("Error", "Home");
            }
            _context.VillaNumbers.Remove(villaNumer);
            _context.SaveChanges();
            TempData["Success"] = "Villa Number Deleted Successfully";
            return RedirectToAction("Index");
        }
        private List<SelectListItem> LoadVillaList()
        {
           return (_context.Villas.Select(sl => new SelectListItem { Text = sl.Name, Value = sl.Id.ToString() }).ToList());
        }

    }

}
