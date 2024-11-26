using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShopApi.Models;
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
        public async Task<ActionResult<ClothesTypesResponse>> GetClothesTypes()
        {
            var items = await _service.GetAllAsync();
            var response = new ClothesTypesResponse{
                ClothesTypes = items.ToList()
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClothesType>> GetClothesType(Guid id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutType(Guid id, ClothesType type)
        {
            var updated = await _service.UpdateAsync(id, type);
            if (!updated) return NotFound();

            return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754   
        [HttpPost]
        public async Task<ActionResult<ClothesType>> PostType(ClothesType type)
        {
            await _service.AddAsync(type);
            return CreatedAtAction(nameof(GetClothesType), new { id = type.Id }, type);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}