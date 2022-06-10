using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Model;
using SalesTest.Interfaces.Base.Repository;

namespace SalesTest.Interfaces.Base.UnitsOfWork
{
    public interface ISalesUnitOfWork
    {
        public IRepository<IBuyer> Buyers { get; }
        public IRepository<IProduct> Products { get; }
        public IRepository<ISalesPoint> SalesPoints { get; }
        public IRepository<ISales> Sales { get; }

        public IInfoModel GetAll()
        {
            return default;
        }
    }
}
