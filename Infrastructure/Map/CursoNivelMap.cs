using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.DTOs.Request.Cursos;

namespace WebApi.Infrastructure.Map
{
    public class CursoNivelMap : IEntityTypeConfiguration<CursoNivelModel>
    {
        public void Configure(EntityTypeBuilder<CursoNivelModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nivel);
        }
    }
}
