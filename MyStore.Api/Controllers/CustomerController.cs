using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyStore.Api.Data;
using MyStore.Api.Models;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ShopDbContext _context;

    public CustomerController(ShopDbContext context)
    {
        _context = context;
    }

    [HttpGet("{customerNumber}")]
    public async Task<ActionResult<Customer>> GetCustomer(string customerNumber)
    {
        var customer = await _context.Customers.FindAsync(customerNumber);
        if (customer == null) return NotFound();
        return customer;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer(Customer customer)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCustomer), new { customerNumber = customer.CustomerNumber }, customer);
    }

    [HttpPut("{customerNumber}")]
    public async Task<IActionResult> UpdateCustomer(string customerNumber, Customer customer)
    {
        if (customerNumber != customer.CustomerNumber) return BadRequest("ID mismatch");
        _context.Entry(customer).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{customerNumber}")]
    public async Task<IActionResult> DeleteCustomer(string customerNumber)
    {
        var customer = await _context.Customers.FindAsync(customerNumber);
        if (customer == null) return NotFound();
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var customers = await _context.Customers
                            .OrderBy(c => c.CustomerNumber)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();
        return Ok(customers);
    }
}
