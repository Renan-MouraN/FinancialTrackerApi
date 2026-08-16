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


    [HttpPut("{id}")]

    public async Task<ActionResult> Update(int id, CreateTransactionDto dto)
    {
        var transacaoExistente = await _context.Transactions.FindAsync(id);  //ENCONTRA A TRANSAÇÃO NO BANCO USANDO O ID RECEBIDO
        if(transacaoExistente == null)
        {
            return NotFound(); //Simplesmente retorna que o objeto não foi encontrado, caso o ID não exista no banco
        }

        transacaoExistente.Value = dto.Value;
        transacaoExistente.TransactionType = dto.TransactionType;
        transacaoExistente.CategoryId = dto.CategoryId;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    

}

