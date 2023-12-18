using Microsoft.AspNetCore.Mvc;
using Trainer.Data;
using Trainer.Models;

namespace Trainer.Controllers
{
    public class TamerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TamerController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Tamer> objTamerList = _db.Tamers.ToList(); 
            return View(objTamerList);
        }
        
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
		public IActionResult Create(Tamer obj)
		{
            if(ModelState.IsValid)
            {
				_db.Tamers.Add(obj);
				_db.SaveChanges();
                TempData["success"] = "Category successfully";
                return RedirectToAction("Index");

			}
            return View();
		}

        public IActionResult Edit(int? Id)
        {
            if(Id  == null || Id== 0)
            {
                TempData["error"] = "error";
                return NotFound();
            }

            Tamer? tamerFromDb = _db.Tamers.FirstOrDefault(t => t.Id == Id);
            if(tamerFromDb == null)
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
				_db.Tamers.Update(obj);
				_db.SaveChanges();
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

			Tamer? tamerFromDb = _db.Tamers.FirstOrDefault(t => t.Id == Id);
			if (tamerFromDb == null)
			{
				return NotFound();
			}
			return View(tamerFromDb);
		}

        [HttpPost]
		public IActionResult Delete(Tamer obj)
		{
            Tamer? deleteObj = _db.Tamers.Find(obj.Id);
            if (deleteObj == null)
            {
                return NotFound();
            }
            _db.Tamers.Remove(deleteObj);
            _db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
