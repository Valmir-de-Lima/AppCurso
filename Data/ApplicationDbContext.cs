using AppCurso.Data.Mappings;
using AppCurso.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppCurso.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Curso>? Cursos { get; set; }
    public DbSet<Modulo>? Modulos { get; set; }
    public DbSet<Aula>? Aulas { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new AulaMap());
        modelBuilder.ApplyConfiguration(new ModuloMap());
        modelBuilder.ApplyConfiguration(new CursoMap());
    }

}
