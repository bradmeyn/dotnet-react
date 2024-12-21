using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api;

[ApiController]
[Route("api/clients")]
public class ClientController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ClientController> _logger;

    public ClientController(ApplicationDbContext context, ILogger<ClientController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> GetClients()
    {
        return await _context.Clients.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> GetClient(Guid id)
    {
        var client = await _context.Clients.FindAsync(id);

        if (client == null)
        {
            return NotFound();
        }

        return client;
    }

[HttpPost]
public async Task<ActionResult<Client>> CreateClient(Client client)
{
    _logger.LogInformation("Creating new client - FirstName: {FirstName}, LastName: {LastName}, Email: {Email}", 
        client.FirstName, 
        client.LastName, 
        client.Email);

    _context.Clients.Add(client);
    await _context.SaveChangesAsync();

    _logger.LogInformation("Successfully created client with ID: {ClientId}", client.Id);

    return CreatedAtAction(
        nameof(GetClient),
        new { id = client.Id },
        client
    );
}

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClient(Guid id, Client client)
    {
        if (id != client.Id)
        {
            return BadRequest();
        }

        _context.Entry(client).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClientExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(Guid id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null)
        {
            return NotFound();
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ClientExists(Guid id)
    {
        return _context.Clients.Any(e => e.Id == id);
    }
}