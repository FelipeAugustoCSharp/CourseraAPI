using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.DTO.Request.Cursos;
using WebApi.DTO.Request.Usuario;
using WebApi.DTOs.Request.Cursos;

namespace WebApi.Infrastructure.Map
{
    public class UsuarioCursoNivelMap : IEntityTypeConfiguration<UsuarioCursoNivelModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioCursoNivelModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne<CursosDadosModel>(x => x.CursoDados).WithMany().HasForeignKey(x => x.CursoDadosId);
            builder.HasOne<UsuarioCadastroRequest>(x => x.Usuario).WithMany().HasForeignKey(x => x.UsuarioId);
            builder.HasOne<CursoNivelModel>(x => x.CursoNivel).WithMany().HasForeignKey(x => x.CursoNivelId);
        }
    }
}
