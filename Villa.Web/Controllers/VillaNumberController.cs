using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Villa.Application.Interface;
using Villa.Domain.Entities;
using Villa.Infrastructure.Data;
using Villa.Web.ViewModels;

namespace Villa.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public VillaNumberController(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var villaNumbers = _unitOfWork.villaNumberRepository.GetAll(includeProperties: [vn => vn.Room]);
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
            if (_unitOfWork.villaNumberRepository.AnyFilter(vn => vn.Villa_Number == obj.VillaNumber.Villa_Number))
            {
                ModelState.AddModelError("VillaNumber.Villa_Number", "Villa Number already used");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.villaNumberRepository.Add(obj.VillaNumber);
                _unitOfWork.villaNumberRepository.Add(obj.VillaNumber);
                _unitOfWork.Commit();
                TempData["Success"] = "Villa Number Created Successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Villa Number Creation Failed";
            obj.VillaList = LoadVillaList();
            return View(obj);
        }
        public IActionResult Update(int id)
        {
            var villaNumber = _unitOfWork.villaNumberRepository.GetSingle(filter: v => v.Villa_Number == id);

            if (villaNumber is null)
            {
                TempData["Error"] = "Villa Number Not Found";

                return RedirectToAction("Error", "Home");
            }
            ViewBag.VillaList =LoadVillaList();
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
                _unitOfWork.villaNumberRepository.Update(obj);
                _unitOfWork.Commit();
                TempData["Success"] = "Villa Number Updated Successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Villa Number Update Failed";
            ViewBag.VillaList =LoadVillaList();
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
            var villaNumber = _unitOfWork.villaNumberRepository.GetSingle(includeProperties: [v => v.Room], filter: v=> v.Villa_Number == id);

            if (villaNumber is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumber);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteVillaNumber(int id)
        {
            var villaNumber = _unitOfWork.villaNumberRepository.GetSingle(filter: v => v.Villa_Number == id);
            if (villaNumber is null)
            {
                TempData["Error"] = "Villa Number not Found";
                return RedirectToAction("Error", "Home");
            }
            _unitOfWork.villaNumberRepository.Remove(villaNumber);
            _unitOfWork.Commit();
            TempData["Success"] = "Villa Number Deleted Successfully";
            return RedirectToAction("Index");
        }
        private IEnumerable<SelectListItem> LoadVillaList()
        {
            return _unitOfWork.roomRepository
                .LoadVillaList()
                .Select(v => new SelectListItem
                {
                    Text = v.Name,
                    Value = v.Id.ToString()
                });
               
        }

    }

}
