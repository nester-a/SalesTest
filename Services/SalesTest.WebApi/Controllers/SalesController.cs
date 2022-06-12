using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Services;
using SalesTest.Interfaces.Extensions;
using SalesTest.Interfaces.Model.Sales;
using System.Linq;

namespace SalesTest.WebApi.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IService<ISales> _service;

        public SalesController(IService<ISales> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var sales = _service.GetAll();

            if (sales.Any())
            {
                var result = sales.Select(x => x.ToModel()).ToList();
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            SalesModel sales;
            try
            {
                sales = _service.GetById(id).ToModel();
            }
            catch
            {
                return NotFound();
            }
            return Ok(sales);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateSalesModel model)
        {
            var sales = model.ToDomain();
            var id = _service.Add(sales);
            if (id == -1)
            {
                return BadRequest(new { Message = $"Data-base has no this buyer, product or sales point. Or you entered product quantity for this sales point is too big" });
            }
            sales.Id = id;

            return CreatedAtAction(nameof(GetById), new { Id = id }, sales.ToModel());
        }

        [HttpPut]
        public IActionResult Edit(SalesModel model)
        {
            var sales = model.ToDomain();
            int result;
            try
            {
                result = _service.Update(model.Id, sales);
                if (result == -1)
                {
                    return BadRequest(new { Message = $"Data-base has no this buyer, product or sales point. Or you entered product quantity for this sales point is too big" });
                }
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
            ISales result;
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
