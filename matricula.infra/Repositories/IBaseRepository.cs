using matricula.infra.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace matricula.infra.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T Find(int id);
        IQueryable<T> List();
        void Add(T item);
        void Remove(T item);
        void Edit(T item);
        void Dispose();
        void AddRange(IEnumerable<T> item);
    }
}
