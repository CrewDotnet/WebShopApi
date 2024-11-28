using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShopApi.Models;
using WebShopApi.Models.RequestModels;
using WebShopApi.Services;

namespace WebShopApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClothesTypesController : ControllerBase
    {
        private readonly ITypesService _service;

        public ClothesTypesController(ITypesService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClothesType>>> GetClothesTypes()
        {
            var types = await _service.GetAllAsync();
            return Ok(types);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClothesType>> GetClothesType(Guid id)
        {
            var type = await _service.GetByIdAsync(id);
            if (type == null)
            {
                return NotFound();
            }
            return Ok(type);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClothesType(Guid id, ClothesTypeRequest typeRequest)
        {
            var updated = await _service.UpdateAsync(id, typeRequest);
            if (!updated) return NotFound();
            return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754   
        [HttpPost]
        public async Task<ActionResult<ClothesType>> PostClothesType(ClothesTypeRequest typeRequest)
        {
            var createdType = await _service.AddAsync(typeRequest);
            return CreatedAtAction(nameof(GetClothesType), new { id = createdType.Id }, createdType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothesType(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}