using Microsoft.AspNetCore.Mvc;
using Insurance_crud_api.DTOs;
using Insurance_crud_api.Services.Interfaces;

namespace Insurance_crud_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PoliciesController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _policyService.GetAllAsync();
            return Ok(data);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var policy = await _policyService.GetByIdAsync(id);
            return policy == null ? NotFound() : Ok(policy);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> Create(PolicyDto dto)
        {
            var policy = await _policyService.CreateAsync(dto);
            return Ok(policy);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PolicyDto dto)
        {
            var policy = await _policyService.UpdateAsync(id, dto);
            return policy == null ? NotFound() : Ok(policy);
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _policyService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}