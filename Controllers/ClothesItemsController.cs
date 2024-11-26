using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebShopApi.Models;
using WebShopApi.Services;

namespace WebShopApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ClothesItemsController : ControllerBase
    {
        private readonly IClothesService _service;

        public ClothesItemsController(IClothesService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<ClothesItemsResponse>> GetClothesItems()
        {
            var items = await _service.GetAllAsync();
            var response = new ClothesItemsResponse{
                ClothesItems = items.ToList()
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClothesItem>> GetClothesItem(Guid id)
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
        public async Task<IActionResult> PutClothesItem(Guid id, ClothesItem item)
        {
            var updated = await _service.UpdateAsync(id, item);
            if (!updated) return NotFound();

            return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClothesItem>> PostClothesItem(ClothesItem item)
        {
            await _service.AddAsync(item);
            return CreatedAtAction(nameof(GetClothesItem), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClothesItem(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
