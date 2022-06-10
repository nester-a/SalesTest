using Microsoft.AspNetCore.Mvc;
using SalesTest.Domain;
using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Model;
using SalesTest.Interfaces.Base.UnitsOfWork;
using SalesTest.Interfaces.Model;
using System.Collections.Generic;
using System.Linq;

namespace SalesTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesUnitOfWork _unitOfWork;

        public SalesController(ISalesUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("/info")]
        public IActionResult AllInfo()
        {
            return Ok(_unitOfWork.GetAll());
        }

        [HttpPost]
        [Route("/sale")]
        public IActionResult Sale([FromBody]SaleModel saleModel)
        {
            var buyer = saleModel.Buyer;
            var salesPointId = saleModel.SalesPointId;
            //есть-ли такой покупатель в принципе
            if (buyer is not null && !_unitOfWork.BuyerExists(buyer.Id))
                return Ok("There are no such buyer in our data-base");

            //проверка существования товара
            foreach (var item in saleModel.ProductsToBuy)
            {
                if(!_unitOfWork.ProductExists(item.Key))
                    return Ok("There are no such product in our data-base");
            }

            //потом смотрим есть ли нужная точка покупки
            if (!_unitOfWork.SalesPointExists(salesPointId))
                return Ok("There are no such sales point in our data-base");

            //получили список товаров к покупке
            var pp = new List<IProvidedProduct>();
            foreach (var item in saleModel.ProductsToBuy)
            {
                pp.Add(new ProvidedProduct()
                {
                    ProductId = item.Key,
                    ProductQuantity = item.Value,
                });
            }

            //проверили, что он есть в наличии в точке
            if(!_unitOfWork.ProductsExistsOnSalesPoint(salesPointId, pp))
                return Ok("Products are not enough in this sales point");

            var sale = new Sales()
            {
                SalesPointId = salesPointId,
                BuyerId = buyer?.Id,
            };
            var salesData = new List<ISalesData>();
            foreach (var item in saleModel.ProductsToBuy)
            {
                salesData.Add(new SalesData()
                {
                    ProductId = item.Key,
                    ProductQuantity = item.Value,
                    ProductIdAmount = _unitOfWork.CountAmount(item.Key, item.Value),
                });
            }
            sale.SalesData = salesData; 
            sale.TotalAmount = salesData.Sum(i => i.ProductIdAmount);

            return Ok(sale);

        }
    }
}
