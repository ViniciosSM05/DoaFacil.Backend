using DoaFacil.Backend.Domain.Entities.ImagemAnuncioEntity;
using DoaFacil.Backend.Infra.Database.Mappings.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoaFacil.Backend.Infra.Database.Mappings
{
    public class ImagemAnuncioMap : BaseEntityMap<ImagemAnuncio>
    {
        public override string TableName => "imagem_anuncio";

        public override void Configure(EntityTypeBuilder<ImagemAnuncio> builder)
        {
            base.Configure(builder);

            builder.Property(i => i.Principal).IsRequired();
            builder.Property(i => i.Url).IsRequired().HasMaxLength(ImagemAnuncio.URL_MAX_LENGTH);

            builder.HasOne(i => i.Anuncio)
                   .WithMany(a => a.Imagens)
                   .HasForeignKey(i => i.AnuncioId);

            builder.HasIndex(i => i.Url);
            builder.HasIndex(i => i.AnuncioId);
        }
    }
}
