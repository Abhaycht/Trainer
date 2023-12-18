using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer.DataAccess.Data;
using Trainer.DataAccess.Repository.IRepository;
using Trainer.Models;

namespace Trainer.DataAccess.Repository
{
    public class TamerRepository : Repository<Tamer>, ITamerRepository
    {
        private ApplicationDbContext _db;
        public TamerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Tamer obj)
        {
            _db.Tamers.Update(obj);
        }
        
    }
}
