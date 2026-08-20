using ActividadWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActividadWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DispositivosController : ControllerBase
{
    private static readonly List<Dispositivo> dispositivos =
    [
        new Dispositivo
        {
            Id = 1,
            Nombre = "Servidor Web",
            Tipo = "Servidor",
            Ip = "192.168.1.10",
            Activo = true
        },
        new Dispositivo
        {
            Id = 2,
            Nombre = "Firewall Principal",
            Tipo = "Firewall",
            Ip = "192.168.1.1",
            Activo = true
        }
    ];

    [HttpGet]
    public ActionResult<IEnumerable<Dispositivo>> Get()
    {
        return Ok(dispositivos);
    }

    [HttpGet("{id}")]
    public ActionResult<Dispositivo> GetById(int id)
    {
        var dispositivo = dispositivos.FirstOrDefault(d => d.Id == id);

        if (dispositivo == null)
            return NotFound();

        return Ok(dispositivo);
    }

    [HttpPost]
    public ActionResult<Dispositivo> Post(Dispositivo dispositivo)
    {
        dispositivo.Id = dispositivos.Count > 0
            ? dispositivos.Max(d => d.Id) + 1
            : 1;

        dispositivos.Add(dispositivo);

        return CreatedAtAction(
            nameof(GetById),
            new { id = dispositivo.Id },
            dispositivo
        );
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Dispositivo dispositivo)
    {
        var existente = dispositivos.FirstOrDefault(d => d.Id == id);

        if (existente == null)
            return NotFound();

        existente.Nombre = dispositivo.Nombre;
        existente.Tipo = dispositivo.Tipo;
        existente.Ip = dispositivo.Ip;
        existente.Activo = dispositivo.Activo;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var dispositivo = dispositivos.FirstOrDefault(d => d.Id == id);

        if (dispositivo == null)
            return NotFound();

        dispositivos.Remove(dispositivo);

        return NoContent();
    }
}