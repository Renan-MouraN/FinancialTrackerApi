using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FinancialTrackerApi.Controllers;

[ApiController]         //Metadado para avisar que esse arquivo é uma Controller
[Route("[controller]")]  //esse 'controller' é um placeholder, o ASP.NET substitui automaticamente pelo nome da classe, é a URL que a Controller vai responder

public class BudgetController : ControllerBase  //cria a classe da controller em si...importante saber que ela herda de ControllerBase, que já contém diversos
                                                //métodos prontos
{
    private readonly ApplicationDbContext _context; //cria uma propriedade privada que não pode ser alterada do tipo DbContext, serve para conectador com a 
                                                    //base de dados, é como um telefone usado para pedir as mudanças

    public BudgetController(ApplicationDbContext context) //construtor que guarda a conexão do banco injetada automaticamente pelo ASP.NET em _context para que
                                                          //os métodos da classe possam usar
    {
        _context = context;
    }

    [HttpGet(Name = "GetBudget")]  //Atributo que define os metadados do verbo GET HTTP

    public async Task<ActionResult<IEnumerable<Budget>>> GetBudget() { //É criada uma função assincrona 
                                                                        
                                                                        //TASK(Representa a criação de uma criação que vai se concluída no futuro, não imediatamente)
                                                                        //ActionResult representa o resultado que sua API vai devolver para o cliente
                                                                        //IEnumerable é uma interface do .NET que representa algo que pode ser percorrido/iterado, normalmente usando foreach.

        var budget = await _context.Budgets.ToListAsync();  //cria a variável budget que serve para puxar o que está na base de dados e armazenar em forma de lista
                                                            //de maneira assincrona

        return Ok(budget);  //retorna o budget com o status Ok (isso é um método da ControllerBase)
    }

    [HttpPost(Name = "PostBudget")]   //Atributo que define os metadados do verbo POST HTTP (CRIAÇÃO)

    public async Task<ActionResult<Budget>> PostBudget([FromBody]CreateBudgetDto dto) //parecida com a função acima, com a diferença que não precisa do Enumerable
                                                                          //pq não vai retornar um lista e o método tem um paramẽtro
                                                                          //[FromBody] pega o parâmetro do corpo da requisição (outros são [FromRoute] {da URL} e [FromQuery] {parametros na URL})
    {
        var novoBudget = new Budget        //Aqui é criado o objeto do budget, com os atributos do dto armazenando oq é passado no corpo da requisição
        {
            UserId = dto.UserId,
            Month = dto.Month,
            Limit =  dto.Limit,
        };

        _context.Budgets.Add(novoBudget);      //Adiciona na base de dados o que foi digitado 
        await _context.SaveChangesAsync();      //salva as mudanças

        return CreatedAtAction(nameof(GetBudget), new {id = novoBudget.BudgetId}, novoBudget);  //retorna que foi criado o objeto e usa do GET para exibir isso
    }

    [HttpPut("{id}")]  //Atributo que define o put, ele indica que o PUT acontece de acordo com o id passado (ATUALIZAÇÃO)

    public async Task<ActionResult> Update(int id, UpdateBudgetDto dto) //O id é necessário para identificar qual transação é alterada e o UpdateBudgetDto
                                                                        //para pegar os campos do budget
    {
        var budgetExistente = await _context.Budgets.FindAsync(id); //ENCONTRA A TRANSAÇÃO NO BANCO USANDO O ID RECEBIDO
        if(budgetExistente == null)  //Verifica se o budget existea
        {
            return NotFound(); //Simplesmente retorna que o objeto não foi encontrado, caso o ID não exista no banco
        }

        //aqui os valores são atualizados
        budgetExistente.UserId = dto.UserId;
        budgetExistente.Month = dto.Month;
        budgetExistente.Limit = dto.Limit;

        await _context.SaveChangesAsync();  //aqui as mudanças são salvas na base de dados

        return NoContent(); //retorna que a operação deu certo e não tem nenhum dado para devolver

    }

}   

