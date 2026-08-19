using ActividadWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActividadWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibrosController : ControllerBase
{
    private static readonly List<Libro> libros =
    [
        new Libro
        {
            Id = 1,
            Titulo = "1984",
            Autor = "George Orwell",
            Anio = 1949
        },
        new Libro
        {
            Id = 2,
            Titulo = "El Hobbit",
            Autor = "J. R. R. Tolkien",
            Anio = 1937
        }
    ];

    [HttpGet]
    public ActionResult<IEnumerable<Libro>> Get()
    {
        return Ok(libros);
    }

    [HttpGet("{id}")]
    public ActionResult<Libro> GetById(int id)
    {
        var libro = libros.FirstOrDefault(l => l.Id == id);

        if (libro == null)
            return NotFound();

        return Ok(libro);
    }

    [HttpPost]
    public ActionResult<Libro> Post(Libro libro)
    {
        libro.Id = libros.Max(l => l.Id) + 1;
        libros.Add(libro);

        return CreatedAtAction(nameof(GetById), new { id = libro.Id }, libro);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Libro libro)
    {
        var existente = libros.FirstOrDefault(l => l.Id == id);

        if (existente == null)
            return NotFound();

        existente.Titulo = libro.Titulo;
        existente.Autor = libro.Autor;
        existente.Anio = libro.Anio;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var libro = libros.FirstOrDefault(l => l.Id == id);

        if (libro == null)
            return NotFound();

        libros.Remove(libro);

        return NoContent();
    }
}