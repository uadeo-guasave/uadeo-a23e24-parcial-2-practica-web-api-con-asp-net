using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Data;
using MyWebApi.Models;
using NuGet.Protocol;

namespace MyWebApi.Controllers;

// https://localhost:5432/api/Carreras
[ApiController]
[Route("api/[controller]")]
public class CarrerasController : ControllerBase
{
    private readonly SqliteDbContext _db;
    public CarrerasController(SqliteDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IEnumerable<Carrera>> Get()
    {
        // Obtener todos los alumnos
        var carreras = await _db.Carreras.ToListAsync();

        return carreras;
    }

    [HttpPost]
    public async Task<ActionResult<Carrera>> Post(Carrera carrera)
    {
        await _db.Carreras.AddAsync(carrera);
        await _db.SaveChangesAsync();

        return Ok(carrera);
    }
}