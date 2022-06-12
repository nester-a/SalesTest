using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Services;
using SalesTest.Interfaces.Extensions;
using SalesTest.Interfaces.Model.Buyer;
using System.Linq;

namespace SalesTest.WebApi.Controllers
{
    [Route("api/buyers")]
    [ApiController]
    public class BuyersController : ControllerBase
    {
        private readonly IService<IBuyer> _service;

        public BuyersController(IService<IBuyer> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var buyers = _service.GetAll();

            if (buyers.Any())
            {
                var result = buyers.Select(x => x.ToModel()).ToList();
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            BuyerModel buyer;
            try
            {
                buyer = _service.GetById(id).ToModel();
            }
            catch
            {
                return NotFound();
            }
            return Ok(buyer);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateBuyerModel model)
        {
            var buyer = model.ToDomain();
            var id = _service.Add(buyer);
            buyer.Id = id;

            return CreatedAtAction(nameof(GetById), new { Id = id }, buyer.ToModel());
        }

        [HttpPut]
        public IActionResult Edit(BuyerModel model)
        {
            var buyer = model.ToDomain();
            int result;
            try
            {
                result = _service.Update(model.Id, buyer);
            }
            catch
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IBuyer result;
            try
            {
                result = _service.Delete(id);
            }
            catch
            {
                return NotFound();
            }
            return Ok(result.ToModel());
        }
    }
}
