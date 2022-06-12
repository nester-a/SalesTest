using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Repository;
using SalesTest.Interfaces.Base.Services;
using System;
using System.Collections.Generic;

namespace SalesTest.Interfaces.Services
{
    public class SalesPointsService : IService<ISalesPoint>
    {
        private readonly IRepository<ISalesPoint> _repo;
        private readonly IRepository<IProduct> _productRepo;

        public SalesPointsService(IRepository<ISalesPoint> repo, IRepository<IProduct> productRepo)
        {
            _repo = repo;
            _productRepo = productRepo;
        }
        public int Add(ISalesPoint item)
        {
            if (!CheckProducts(item.ProvidedProducts))
            {
                return -1;
            }
            var result = _repo.Add(item);
            _repo.Save();
            return result;
        }

        public ISalesPoint Delete(int id)
        {
            var result = _repo.Delete(id);
            _repo.Save();
            return result;
        }

        public List<ISalesPoint> GetAll()
        {
            return _repo.GetAll();
        }

        public ISalesPoint GetById(int id)
        {
            return _repo.GetById(id);
        }

        public int Update(int id, ISalesPoint updatedItem)
        {
            if (!CheckProducts(updatedItem.ProvidedProducts))
            {
                return -1;
            }
            var result = _repo.Update(id, updatedItem);
            _repo.Save();
            return result;
        }

        private bool CheckProducts(IEnumerable<IProvidedProduct> providedProducts)
        {
            foreach (var pp in providedProducts)
            {
                if (!_productRepo.Exists(pp.ProductId))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
