using System.Collections.Generic;
using System.Linq;


namespace matricula.domain.Services
{
    public interface IBaseService<T> where T : class
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
