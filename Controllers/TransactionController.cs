using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FinancialTrackerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    private int? Month;

    private int? Year;

    public TransactionController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetTransactions")]

    public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions()
    {
        var transactions = await _context.Transactions.ToListAsync();

        return Ok(transactions);
    }
       


}

