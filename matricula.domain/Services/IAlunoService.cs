using matricula.infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace matricula.domain.Services
{
    public interface IAlunoService : IBaseService<Aluno>, IDisposable
    {
       
    }
}
