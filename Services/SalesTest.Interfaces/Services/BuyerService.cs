using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Repository;
using SalesTest.Interfaces.Base.Services;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Services
{
    public class BuyerService : IService<IBuyer>
    {
        private readonly IRepository<IBuyer> _repo;

        public BuyerService(IRepository<IBuyer> repo)
        {
            _repo = repo;
        }
        public int Add(IBuyer item)
        {
            var result = _repo.Add(item);
            _repo.Save();
            return result;
        }

        public IBuyer Delete(int id)
        {
            var result = _repo.Delete(id);
            _repo.Save();
            return result;
        }

        public List<IBuyer> GetAll()
        {
            return _repo.GetAll();
        }

        public IBuyer GetById(int id)
        {
            return _repo.GetById(id);
        }

        public int Update(int id, IBuyer updatedItem)
        {
            var result = _repo.Update(id, updatedItem);
            _repo.Save();
            return result;
        }
    }
}
