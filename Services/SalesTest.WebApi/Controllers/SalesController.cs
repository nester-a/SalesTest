using Microsoft.AspNetCore.Mvc;
using SalesTest.Interfaces.Base.UnitsOfWork;
using SalesTest.Interfaces.Model;

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

        /// <summary>Get all information about buyers, sale point, products and sales</summary>
        /// <returns>List of information</returns>
        [HttpGet]
        [Route("/info")]
        public IActionResult AllInfo()
        {
            return Ok(_unitOfWork.GetAll());
        }

        /// <summary>Do sales action</summary>
        /// <param name="saleModel">Who, where, buy what</param>
        /// <returns>Sales action result</returns>
        [HttpPost]
        [Route("/sale")]
        public IActionResult Sale([FromBody]SaleModel saleModel)
        {
            //есть-ли такой покупатель в принципе
            if (saleModel.BuyerId is not null && !_unitOfWork.BuyerExists((int)saleModel.BuyerId))
                return Ok("There are no such buyer in our data-base");

            //проверка существования товара
            foreach (var item in saleModel.ProductsToBuy)
            {
                if(!_unitOfWork.ProductExists(item.Key))
                    return Ok("There are no such product in our data-base");
            }

            //потом смотрим есть ли нужная точка покупки
            if (!_unitOfWork.SalesPointExists(saleModel.SalesPointId))
                return Ok("There are no such sales point in our data-base");

            //получили список товаров к покупке
            var pp = _unitOfWork.GetProvidedProducts(saleModel);

            //проверили, что он есть в наличии в точке
            if(!_unitOfWork.ProductsExistsOnSalesPoint(saleModel.SalesPointId, pp))
                return Ok("Products are not enough in this sales point");

            //совершили продажу
            var sale = _unitOfWork.MakeASale(saleModel, pp);

            return Ok(sale);

        }
    }
}
