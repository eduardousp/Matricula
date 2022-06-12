using matricula.infra.Context;
using matricula.infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matricula.infra.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {

          public AlunoRepository(DataContext context) : base(context)
            {
               
            }
     }
}
