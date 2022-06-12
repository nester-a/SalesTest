using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Repository;
using SalesTest.Interfaces.Base.Services;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Services
{
    ///<inheritdoc cref="IService<T>"/>
    public class ProductService : IService<IProduct>
    {
        private readonly IRepository<IProduct> _repo;

        public ProductService(IRepository<IProduct> repo)
        {
            _repo = repo;
        }
        public int Add(IProduct item)
        {
            return _repo.Add(item);
        }

        public IProduct Delete(int id)
        {
            return _repo.Delete(id);
        }

        public List<IProduct> GetAll()
        {
            return _repo.GetAll();
        }

        public IProduct GetById(int id)
        {
            return _repo.GetById(id);
        }

        public int Update(int id, IProduct updatedItem)
        {
            return _repo.Update(id, updatedItem);
        }
    }
}
