using Microsoft.AspNetCore.Mvc;
using Trainer.DataAccess.Data;
using Trainer.Models;
using Trainer.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Trainer.Utility;

namespace TrainerWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize(Roles = SD.Role_Customer)]
    public class TamerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TamerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Tamer> objTamerList = _unitOfWork.Tamer.GetAll().ToList();
            return View(objTamerList);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Tamer obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Tamer.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Created successfully";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                TempData["error"] = "error";
                return NotFound();
            }

            Tamer? tamerFromDb = _unitOfWork.Tamer.Get(t => t.Id == Id);
            if (tamerFromDb == null)
            {
                return NotFound();
            }
            return View(tamerFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Tamer obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Tamer.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Updated successfully";
                return RedirectToAction("Index");

            }
            return View();

        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                TempData["error"] = "error";
                return NotFound();
            }

            Tamer? tamerFromDb = _unitOfWork.Tamer.Get(t => t.Id == Id);
            if (tamerFromDb == null)
            {
                return NotFound();
            }
            return View(tamerFromDb);
        }

        [HttpPost]
        public IActionResult Delete(Tamer obj)
        {
            Tamer? deleteObj = _unitOfWork.Tamer.Get(t => t.Id == obj.Id);
            if (deleteObj == null)
            {
                return NotFound();
            }
            _unitOfWork.Tamer.Remove(deleteObj);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
