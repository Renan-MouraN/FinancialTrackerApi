using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FinancialTrackerApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController : ControllerBase   //CRIAÇÃO DA CLASSE, esse ControllerBase é uma classe base do ASP.NET Core que tem métodos e classes fundamentais
{
    private readonly ApplicationDbContext _context; //CRIA A PROPRIEDADE PARA ARMAZENAR O CONTEXTO DA BASE DE DADOS
    public CategoriesController(ApplicationDbContext context)  //CONSTRUTOR DA CLASSE
    {
        _context = context; //Essa é a propriedade que traz o contexto da tabela da base de dados
    }

    [HttpGet(Name = "GetCategories")]  //ISSO ENTRE COLCHETES SÃO OS ATRIBUTOS...ELES SERVEM PARA ADICIONAR METADADOS SEM MUDAR O COMPORTAMENTO DO CÓDIGO DIRETAMENTE, NESSE CASO, DEFINE O VERBO HTTP
    
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()  //ESSE É O MÉTODO GET EM SI...É UM MÉTODO PÚBLICO ASSINCRONO (PORQUE PRECISAR "PEGAR" ALGO FORA DO CÓDIGO, NO CASO, A BASE)
    {
        var categories = await _context.Categories.ToListAsync();   //ESSA É A VARIÁVEL QUE ARMAZENA AS CATEGORIAS...O AWAIT É PARA AGUARDAR A INFORMAÇÃO SER RECUPERADA DA BASE 
        //_context.Categories - Acessa a tabela de categorias através do DbContext e o .ToListAsync transforma o resultado da consulta em uma lista de forma assíncrona
        return Ok(categories);
    }

}