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

    [HttpGet]
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
}