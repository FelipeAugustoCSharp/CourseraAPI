using Microsoft.EntityFrameworkCore;
using WebApi.DTO.Request.Cursos;
using WebApi.DTO.Request.Usuario;
using WebApi.DTOs.Request.Cursos;
using WebApi.Infrastructure.Map;

namespace WebApi.Infrastructure
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        
        }
        public DbSet<UsuarioCadastroRequest> UsuarioCadastro { get; set; }

        public DbSet<CursoNivelModel> CursoNivel { get; set; }
        public DbSet<CursosDadosModel> CursoDados { get; set; }
        public DbSet<CursoContent> CursoContent { get; set; }
        public DbSet<UsuarioCursoNivelModel> UsuarioCursoNivel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserCadastroMap());
            modelBuilder.ApplyConfiguration(new CursoContentMap());
            modelBuilder.ApplyConfiguration(new CursoNivelMap());
            modelBuilder.ApplyConfiguration(new CursosDadosMap());
            modelBuilder.ApplyConfiguration(new UsuarioCursoNivelMap());
            modelBuilder.ApplyConfiguration(new UserCadastroMap());
            base.OnModelCreating(modelBuilder);
        }




    }
}