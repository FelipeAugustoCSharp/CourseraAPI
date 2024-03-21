using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.DTO.Request;
using WebApi.DTO.Request.Usuario;
namespace WebApi.Infrastructure.Map
{
    public class UserCadastroMap : IEntityTypeConfiguration<UsuarioCadastroRequest>
    {
        public void Configure(EntityTypeBuilder<UsuarioCadastroRequest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email );
            builder.Property(x => x.Senha);
        }
    }
}
