using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITamerRepository Tamer {  get; }

        void Save();
    }
}
