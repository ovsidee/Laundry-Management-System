using Microsoft.AspNetCore.Mvc;
using Test2.Services;

namespace Test2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    public IDbService _service { get; set; }
    
    public CustomersController(IDbService service)
    {
        _service = service;
    }
    
    [HttpGet("{customerId}/purchases")]
    public async Task<IActionResult> GetCustomerWithPurchasesDetailsAsync(int customerId, CancellationToken cancellationToken)
    {
        if (customerId < 0)
            return BadRequest("Id must be greater than 0");
        
        var result = await _service.GetCustomerWithPurchasesAsync(customerId, cancellationToken);
        
        if (result == null)
            return NotFound($"Customer not found with id: \"{customerId}\"");
        
        return Ok(result);
    }
}