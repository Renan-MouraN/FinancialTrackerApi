using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FinancialTrackerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ApplicationDbContext _context;



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
       
    [HttpPost(Name = "PostTransactions")]

    public async Task<ActionResult<Transaction>> PostTransactions([FromBody] CreateTransactionDto dto)
    {
        var novaTransacao = new Transaction
        {   
            Value = dto.Value,
            TransactionType = dto.TransactionType,
            CategoryId = dto.CategoryId
        };

        _context.Transactions.Add(novaTransacao);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTransactions), new { id = novaTransacao.TransactionId }, novaTransacao);
    }

}

