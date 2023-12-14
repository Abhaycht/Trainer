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
    }
}
