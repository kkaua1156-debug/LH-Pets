using LH_Pets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LH_Pets.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PetsController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Pet>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Pet>> Get()
    {
        return Ok(BancoEmMemoria.Pets);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Pet), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Pet> Post([FromBody] Pet pet)
    {
        var clienteExiste = BancoEmMemoria.Clientes.Any(c => c.Id == pet.ClienteId);
        if (!clienteExiste)
        {
            return NotFound(new { mensagem = $"Cliente com ID {pet.ClienteId} não encontrado." });
        }

        pet.Id = BancoEmMemoria.ProximoPetId;
        BancoEmMemoria.Pets.Add(pet);
        return CreatedAtAction(nameof(Get), new { id = pet.Id }, pet);
    }

    [HttpGet("cliente/{clienteId:int}")]
    [ProducesResponseType(typeof(IEnumerable<Pet>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<Pet>> GetPorCliente(int clienteId)
    {
        var clienteExiste = BancoEmMemoria.Clientes.Any(c => c.Id == clienteId);
        if (!clienteExiste)
        {
            return NotFound(new { mensagem = $"Cliente com ID {clienteId} não encontrado." });
        }

        return Ok(BancoEmMemoria.Pets.Where(p => p.ClienteId == clienteId).ToList());
    }
}
