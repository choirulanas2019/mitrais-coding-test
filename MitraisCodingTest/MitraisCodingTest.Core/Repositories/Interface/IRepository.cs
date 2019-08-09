using MitraisCodingTest.Core.Models;
using System.Collections.Generic;

namespace MitraisCodingTest.Core.Repositories.Interface
{
    public interface IRepository<T>
        where T : BaseModel
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        T Add(T item);

        bool Update(T item);

        bool Delete(int id);
    }
}
