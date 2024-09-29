using DoaFacil.Backend.Domain.Entities.EnderecoUsuarioEntity;
using DoaFacil.Backend.Infra.Database.Mappings.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoaFacil.Backend.Infra.Database.Mappings
{
    public class EnderecoUsuarioMap : BaseEntityMap<EnderecoUsuario>
    {
        public override string TableName => "endereco_usuario";

        public override void Configure(EntityTypeBuilder<EnderecoUsuario> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Cep).IsRequired().HasMaxLength(EnderecoUsuario.CEP_MAX_LENGTH);
            builder.Property(e => e.Rua).IsRequired().HasMaxLength(EnderecoUsuario.RUA_MAX_LENGTH);
            builder.Property(e => e.Bairro).IsRequired().HasMaxLength(EnderecoUsuario.BAIRRO_MAX_LENGTH);
            builder.Property(e => e.Numero).IsRequired();

            builder.HasOne(e => e.Cidade)
                   .WithMany(c => c.Enderecos)
                   .HasForeignKey(e => e.CidadeId);

            builder.HasOne(e => e.Usuario)
                   .WithMany(u => u.Enderecos)
                   .HasForeignKey(e => e.UsuarioId);

            builder.HasIndex(e => e.CidadeId);
            builder.HasIndex(e => e.UsuarioId);
        }
    }
}
