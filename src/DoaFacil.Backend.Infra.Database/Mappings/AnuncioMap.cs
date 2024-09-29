using DoaFacil.Backend.Domain.Entities.AnuncioEntity;
using DoaFacil.Backend.Infra.Database.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoaFacil.Backend.Infra.Database.Mappings
{
    public class AnuncioMap : BaseEntityMap<Anuncio>
    {
        public override string TableName => "anuncio";

        public override void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            base.Configure(builder);

            builder.Property(a => a.Codigo).IsRequired();
            builder.Property(a => a.Titulo).IsRequired().HasMaxLength(Anuncio.TITULO_MAX_LENGTH);
            builder.Property(a => a.Descricao).IsRequired();
            builder.Property(a => a.Data).IsRequired();
            builder.Property(a => a.Meta).IsRequired().HasColumnType("decimal(15, 2)");
            builder.Property(a => a.ChavePix).IsRequired().HasMaxLength(Anuncio.CHAVE_PIX_MAX_LENGTH);

            builder.HasOne(a => a.Categoria)
                   .WithMany(c => c.Anuncios)
                   .HasForeignKey(a => a.CategoriaId);

            builder.HasOne(a => a.Usuario)
                   .WithMany(u => u.Anuncios)
                   .HasForeignKey(a => a.UsuarioId);

            builder.HasIndex(a => a.Codigo);
            builder.HasIndex(a => a.Data);
            builder.HasIndex(a => a.CategoriaId);
            builder.HasIndex(a => a.UsuarioId);
        }
    }
}
