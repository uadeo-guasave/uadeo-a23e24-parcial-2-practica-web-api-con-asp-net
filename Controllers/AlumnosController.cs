using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Models;
using NuGet.Protocol;

namespace MyWebApi.Controllers;

// https://localhost:5432/api/Alumno
[ApiController]
[Route("api/[controller]")]
public class AlumnosController : ControllerBase
{
    private readonly SqliteDbContext _db;
    public AlumnosController(SqliteDbContext db)
    {
        _db = db;
    }

    [HttpGet] // https://localhost:7040/api/Alumnos/
    public async Task<IEnumerable<Alumno>> Get()
    {
        // Obtener todos los alumnos
        var alumnos = await _db.Alumnos.ToListAsync();

        return alumnos;
    }

    [HttpPost]
    public async Task<ActionResult<Alumno>> Post(Alumno alumno)
    {
        await _db.Alumnos.AddAsync(alumno);
        await _db.SaveChangesAsync();

        return Ok(alumno);
    }

    [HttpGet("{id}")] // https://localhost:7040/api/Alumnos/1
    public async Task<ActionResult<Alumno>> FindAlumnoById(int id)
    {
        // validar id
        if (id == 0)
        {
            return BadRequest();
        }

        // buscar el alumno en la base de datos
        var alumno = await GetAlumnoById(id); // retorna Alumno o null
        if (alumno is null)
        {
            return NotFound();
        }

        return Ok(alumno);
    }

    private Task<Alumno?> GetAlumnoById(int id)
    {
        return Task.Run(() => _db.Alumnos.Find(id));
    }

    // http put patch
    [HttpPut("edit/{id}")] // https://localhost:7070/api/Alumnos/edit/1
    public async Task<IActionResult> UpdateAlumno(int id, [FromBody] Alumno alumnoDatosNuevos)
    {
        if (alumnoDatosNuevos is null || id != alumnoDatosNuevos.Id)
        {
            return BadRequest();
        }

        var alumno = await GetAlumnoById(id);
        if (alumno is null)
        {
            return NotFound();
        }

        alumno.Matricula = alumnoDatosNuevos.Matricula;
        alumno.Nombres = alumnoDatosNuevos.Nombres;
        alumno.Apellidos = alumnoDatosNuevos.Apellidos;

        _db.Alumnos.Update(alumno);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}