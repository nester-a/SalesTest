using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Services;
using SalesTest.Interfaces.Extensions;
using SalesTest.Interfaces.Model.Product;
using System.Linq;

namespace SalesTest.WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IService<IProduct> _service;

        public ProductsController(IService<IProduct> service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _service.GetAll();

            if (products.Any())
            {
                var result = products.Select(x => x.ToModel()).ToList();
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            ProductModel product;
            try
            {
                product = _service.GetById(id).ToModel();
            }
            catch
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateProductModel model)
        {
            var product = model.ToDomain();
            var id = _service.Add(product);
            product.Id = id;

            return CreatedAtAction(nameof(GetById), new { Id = id }, product.ToModel());
        }

        [HttpPut]
        public IActionResult Edit(ProductModel model)
        {
            var product = model.ToDomian();
            int result;
            try
            {
                result = _service.Update(model.Id, product);
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
            IProduct result;
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
