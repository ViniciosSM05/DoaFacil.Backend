using DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity;
using DoaFacil.Backend.Infra.Database.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoaFacil.Backend.Infra.Database.Mappings
{
    public class ImagemAnuncioMap : BaseEntityMap<ImagemAnuncio>
    {
        public override string TableName => "imagem_anuncio";

        public override void Configure(EntityTypeBuilder<ImagemAnuncio> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.Nome)
                .IsRequired()
                .HasMaxLength(ImagemAnuncio.NOME_MAX_LENGTH);

            builder.Property(i => i.Conteudo)
                .IsRequired()
                .HasColumnType("MEDIUMBLOB");

            builder.Property(i => i.Tipo)
                .IsRequired()
                .HasMaxLength(ImagemAnuncio.TIPO_MAX_LENGTH);

            builder.Property(i => i.Principal)
                .IsRequired();

            builder.HasOne(i => i.Anuncio)
                .WithMany(a => a.Imagens)
                .HasForeignKey(i => i.AnuncioId);

            builder.HasIndex(i => i.AnuncioId);
        }
    }
}
