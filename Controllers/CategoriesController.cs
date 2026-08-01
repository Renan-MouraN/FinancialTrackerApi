using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FinancialTrackerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase
{
    
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext  context)
    {
        
        _context = context;
    }

    [HttpGet(Name = "GetCategories")]
    
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        var categorias = await _context.Categories.ToListAsync();

        return Ok(categorias);
    }

}