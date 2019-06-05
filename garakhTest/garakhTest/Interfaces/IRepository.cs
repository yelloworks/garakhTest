using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace garakhTest.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> ReadList();

        void Create(T item);
        T Read(int id);
        void Update(T item);
        void Delete(int id);

        void Save();
    }
}
