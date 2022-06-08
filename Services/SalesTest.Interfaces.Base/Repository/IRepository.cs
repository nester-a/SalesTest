using SalesTest.Domain.Base;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Base.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        int Add(T item);

        int Update(int id, T updatedItem);

        List<T> GetAll();

        T GetById(int id);

        T Delete(int id);

        void Save();
    }
}