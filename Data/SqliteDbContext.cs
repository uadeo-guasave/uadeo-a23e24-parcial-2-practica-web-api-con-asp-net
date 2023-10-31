using Microsoft.EntityFrameworkCore;
using MyWebApi.Models;

namespace MyWebApi.Data;

public class SqliteDbContext : DbContext
{
    public DbSet<Alumno> Alumnos { get; set; }
    public DbSet<Carrera> Carreras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Data/caps.db");
        base.OnConfiguring(optionsBuilder);
    }

    public SqliteDbContext(DbContextOptions options) : base(options)
    {
    }
}