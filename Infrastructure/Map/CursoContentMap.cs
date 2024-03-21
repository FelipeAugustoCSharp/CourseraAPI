using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.DTO.Request.Cursos;
using WebApi.DTOs.Request.Cursos;

namespace WebApi.Infrastructure.Map
{
    public class CursoContentMap : IEntityTypeConfiguration<CursoContent>
    {
        public void Configure(EntityTypeBuilder<CursoContent> builder)
        {
            builder.HasKey(x => x.Id);
            // Configuração correta da relação com CursosDadosModel
            builder.HasOne<CursoNivelModel>(x => x.CursoNivel).WithMany().HasForeignKey(x => x.CursoNivelId);
            builder.HasOne<CursosDadosModel>(x => x.CursoDados).WithMany().HasForeignKey(x => x.CursoDadosId);
            builder.Property(x => x.urlVideo);
            builder.Property(x => x.Titulo);
            builder.Property(x => x.Conteudo);
        }
    }
}