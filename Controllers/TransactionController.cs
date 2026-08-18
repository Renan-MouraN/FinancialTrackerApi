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
        var novaTransacao = new Transaction //Aqui é criado o objeto (diferente do PUT, que não se cria, só atualiza)
        {   
            Value = dto.Value,
            TransactionType = dto.TransactionType,
            CategoryId = dto.CategoryId
        };

        _context.Transactions.Add(novaTransacao); //Adiciona na base de dados, nas transações, o objeto criado
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTransactions), new { id = novaTransacao.TransactionId }, novaTransacao); //retorna que o objeto foi criado e mostra o que foi
    }


    [HttpPut("{id}")]

    public async Task<ActionResult> Update(int id, UpdateTransactionDto dto)    //O id é necessário para identificar qual transação é alterada e o UpdateTransaction
                                                                                //para pegar os campos da transação
    {
        var transacaoExistente = await _context.Transactions.FindAsync(id);  //ENCONTRA A TRANSAÇÃO NO BANCO USANDO O ID RECEBIDO
        if(transacaoExistente == null)
        {
            return NotFound(); //Simplesmente retorna que o objeto não foi encontrado, caso o ID não exista no banco
        }
        //aqui os valores são atualizados
        transacaoExistente.Value = dto.Value;
        transacaoExistente.TransactionType = dto.TransactionType;
        transacaoExistente.CategoryId = dto.CategoryId;
        //aqui as mudanças são salvas na base de dados
        await _context.SaveChangesAsync();

        return NoContent(); //retorna que a operação deu certo e não tem nenhum dado para devolver
    }

    [HttpDelete("{id}")]

    public async Task<ActionResult> Delete(int id)
    {
        var transacaoExistente = await _context.Transactions.FindAsync(id);
        if(transacaoExistente == null)
        {
            return NotFound();
        }

        _context.Transactions.Remove(transacaoExistente);

        await _context.SaveChangesAsync();

        return NoContent(); 


    }

}

