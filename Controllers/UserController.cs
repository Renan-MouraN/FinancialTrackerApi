using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FinancialTrackerApi.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context) {
        _context = context;
    }

    [HttpGet("{id}", Name = "GetUser")]

    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if(user==null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPut("{id}")]

    public async Task<ActionResult<User>> UpdateUser(int id, UpdateUserDto dto)
    {

        var userExistente = await _context.Users.FindAsync(id);

        if(userExistente == null)
        {
            return NotFound();
        }   

        userExistente.Email = dto.Email;
        userExistente.FullName = dto.FullName;

        await _context.SaveChangesAsync();

        return NoContent();

    }

    [HttpDelete("{id}")] 

    public async Task<ActionResult> DeleteUser(int id)
    {
        var userExistente = await _context.Users.FindAsync(id);

        if(userExistente == null) {
        return NotFound();
        }

        _context.Users.Remove(userExistente);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    

}