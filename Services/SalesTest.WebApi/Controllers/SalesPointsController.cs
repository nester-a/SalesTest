using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Services;
using SalesTest.Interfaces.Extensions;
using SalesTest.Interfaces.Model.SalesPoint;
using System.Linq;

namespace SalesTest.WebApi.Controllers
{
    [Route("api/salespoints")]
    [ApiController]
    public class SalesPointsController : ControllerBase
    {
        private readonly IService<ISalesPoint> _service;

        public SalesPointsController(IService<ISalesPoint> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var salesPoints = _service.GetAll();

            if (salesPoints.Any())
            {
                var result = salesPoints.Select(x => x.ToModel()).ToList();
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            SalesPointModel salesPoints;
            try
            {
                salesPoints = _service.GetById(id).ToModel();
            }
            catch
            {
                return NotFound();
            }
            return Ok(salesPoints);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateSalesPointModel model)
        {
            var salesPoints = model.ToDomain();
            var id = _service.Add(salesPoints);
            if(id == -1)
            {
                return BadRequest(new { Message = $"Data-base has no product with one model's provided product id" });
            }
            salesPoints.Id = id;

            return CreatedAtAction(nameof(GetById), new { Id = id }, salesPoints.ToModel());
        }

        [HttpPut]
        public IActionResult Edit(SalesPointModel model)
        {
            var salesPoints = model.ToDomain();
            int result;
            try
            {
                result = _service.Update(model.Id, salesPoints);
                if (result == -1)
                {
                    return BadRequest(new { Message = $"Data-base has no product with one model's provided product id" });
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
            ISalesPoint result;
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
