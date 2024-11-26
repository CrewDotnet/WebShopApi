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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController (IOrderService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<OrderResponse>> GetOrders()
        {
            var items = await _service.GetAllAsync();
            var response = new OrderResponse{
                Orders = items.ToList()
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
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
        public async Task<IActionResult> PutOrder(Guid id, Order order)
        {
            var updated = await _service.UpdateAsync(id, order);
            if (!updated) return NotFound();

            return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754   
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            await _service.AddAsync(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}