using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.DTO.Request.Cursos;

namespace WebApi.Infrastructure.Map
{
    public class CursosDadosMap : IEntityTypeConfiguration<CursosDadosModel>
    {
        public void Configure(EntityTypeBuilder<CursosDadosModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Photo);
            builder.Property(x => x.Description);
        }
    }
}
