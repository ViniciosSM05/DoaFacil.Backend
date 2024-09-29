using DoaFacil.Backend.Domain.Entities.UsuarioEntity;
using DoaFacil.Backend.Infra.Database.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoaFacil.Backend.Infra.Database.Mappings
{
    public class UsuarioMap : BaseEntityMap<Usuario>
    {
        public override string TableName => "usuario";

        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Nome).IsRequired().HasMaxLength(Usuario.NOME_MAX_LENGTH);
            builder.Property(u => u.CpfCnpj).IsRequired().HasMaxLength(Usuario.CPFCNPJ_MAX_LENGTH);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(Usuario.EMAIL_MAX_LENGTH);
            builder.Property(u => u.Senha).IsRequired().HasMaxLength(Usuario.SENHA_MAX_LENGTH);
            builder.Property(u => u.Celular).IsRequired().HasMaxLength(Usuario.CELULAR_MAX_LENGTH);
            builder.Property(u => u.DataNascimento).IsRequired();

            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasIndex(u => new { u.Email, u.Senha }).HasDatabaseName("email_senha");
        }
    }
}
