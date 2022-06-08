using SalesTest.Domain.Base;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Base.Services
{
    public interface IService<T> where T : IEntity
    {
        int Add(T item);

        int Update(int id, T updatedItem);

        List<T> GetAll();

        T GetById(int id);

        T Delete(int id);
    }
}
