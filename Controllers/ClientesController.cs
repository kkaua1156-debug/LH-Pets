using LH_Pets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LH_Pets.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Cliente>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Cliente>> Get()
    {
        return Ok(BancoEmMemoria.Clientes);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Cliente> Post([FromBody] Cliente cliente)
    {
        cliente.Id = BancoEmMemoria.ProximoClienteId;
        BancoEmMemoria.Clientes.Add(cliente);
        return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
    }
}
