using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesTest.Domain.Base;
using SalesTest.Interfaces.Base.Services;
using SalesTest.Interfaces.Extensions;
using SalesTest.Interfaces.Model.Product;
using System.Linq;

namespace SalesTest.WebApi.Controllers
{
    [Route("api/[controller]")]
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
                var result = products.Select(x => ModelExtensions.ToModel(x)).ToList();
                return Ok(result);
            }
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            //var employee = employeesData.GetById(id);
            //if (employee is null)
            //    return NoContent();

            //var dto = EmployeeMapper.EntityToDTO(employee);
            //return Ok(dto);
            return default;
        }

        [HttpPost]
        public IActionResult Add([FromBody] string dto)
        {
            //var employee = EmployeeMapper.DTOToEntity(dto);
            //var id = employeesData.Add(employee);
            //return CreatedAtAction(nameof(GetById), new { Id = id }, EmployeeMapper.EntityToDTO(employee));
            return default;
        }

        [HttpPut]
        public IActionResult Edit(string dto)
        {
            //var employee = EmployeeMapper.DTOToEntity(dto);
            //var result = employeesData.Edit(employee);
            //return Ok(result);
            return default;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //var result = employeesData.Delete(id);
            //return result
            //    ? Ok(true)
            //    : NotFound(false);
            return default;
        }
    }
}
