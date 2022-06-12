using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Repository;
using SalesTest.Interfaces.Base.Services;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Services
{
    public class SalesService : IService<ISales>
    {
        private readonly IRepository<ISales> _repo;

        public SalesService(IRepository<ISales> repo)
        {
            _repo = repo;
        }
        public int Add(ISales item)
        {
            throw new System.NotImplementedException();
        }

        public ISales Delete(int id)
        {
            var result = _repo.Delete(id);
            _repo.Save();
            return result;
        }

        public List<ISales> GetAll()
        {
            return _repo.GetAll();
        }

        public ISales GetById(int id)
        {
            return _repo.GetById(id);
        }

        public int Update(int id, ISales updatedItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
