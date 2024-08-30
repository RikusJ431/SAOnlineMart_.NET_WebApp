using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAOnlineMart.Models; // Adjust this namespace according to your project structure
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OrderController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Order
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
    {
        return await _context.Orders.Include(o => o.OrderItems).ToListAsync();
    }

    // GET: api/Order/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _context.Orders.Include(o => o.OrderItems)
                                         .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    // POST: api/Order
    [HttpPost]
    public async Task<ActionResult<Order>> PostOrder(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
    }
}
