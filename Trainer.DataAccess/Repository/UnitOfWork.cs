using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trainer.DataAccess.Data;
using Trainer.DataAccess.Repository.IRepository;

namespace Trainer.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ITamerRepository Tamer { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Tamer = new TamerRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
