using Microsoft.AspNetCore.Mvc;
using MyWebApi.Data;
using NuGet.Protocol;

namespace MyWebApi.Controllers;

// https://localhost:5432/api/Alumno
[ApiController]
[Route("api/[controller]")]
public class AlumnoController : ControllerBase
{
    private readonly SqliteDbContext _db;
    public AlumnoController(SqliteDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public string Get()
    {
        // Obtener todos los alumnos
        var alumnos = _db.Alumnos.ToList();
        if (alumnos.Count == 0)
        {
            // avisar que no tiene registros de alumnos
        }

        return alumnos.ToJson();
    }
}