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
				
			}
			return RedirectToAction("Index");
		}

        public IActionResult Edit(int? Id)
        {
            if(Id  == null || Id== 0)
            {
                return NotFound();
            }

            Tamer? tamerFromDb = _db.Tamers.FirstOrDefault(t => t.Id == Id);
            if(tamerFromDb == null)
            {
                return NotFound();
            }
            return View(tamerFromDb);
        }

	}
}
