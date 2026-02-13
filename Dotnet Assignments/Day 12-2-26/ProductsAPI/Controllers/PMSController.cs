using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOs;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PMSController : ControllerBase
    {
        private readonly IProductService _service;
        public PMSController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var product = _service.GetById(id);

            if (product == null)
                return NotFound();

            return Ok(product);

        }

        [HttpPost]

        public IActionResult Create(ProductCreateDTO dto)
        {
            var product=_service.Create(dto);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }


        [HttpPut("{id}")]

        public IActionResult UpdatePut(int id, ProductUpdateDTO dto)
        {
            if (!_service.UpdatePut(id, dto))
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id}")]

        public IActionResult UpdatePatch(int id, ProductUpdateDTO dto)
        {
            if (!_service.UpdatePatch(id, dto)) return NotFound();

            return NoContent();
        }

        [HttpDelete]

        public IActionResult Delete(ProductDeleteDTO dto)
        {
            if(!_service.Delete(dto))
                return NotFound("Product with this id is not found");

            return NoContent();
        }
    }
}
