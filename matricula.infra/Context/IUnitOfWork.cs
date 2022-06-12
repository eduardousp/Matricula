using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matricula.infra.Context
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
