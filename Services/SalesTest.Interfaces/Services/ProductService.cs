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
            var result = _repo.Add(item);
            _repo.Save();
            return result;
        }

        public IProduct Delete(int id)
        {
            var result = _repo.Delete(id);
            _repo.Save();
            return result;
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
            var result = _repo.Update(id, updatedItem);
            _repo.Save();
            return result;
        }
    }
}
