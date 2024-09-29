using DoaFacil.Backend.Domain.Entities.DoacaoEntity;
using DoaFacil.Backend.Infra.Database.Mappings.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoaFacil.Backend.Infra.Database.Mappings
{
    public class DoacaoMap : BaseEntityMap<Doacao>
    {
        public override string TableName => "doacao";

        public override void Configure(EntityTypeBuilder<Doacao> builder)
        {
            base.Configure(builder);

            builder.Property(d => d.Valor).IsRequired().HasColumnType("decimal(15, 2)");
            builder.Property(d => d.Data).IsRequired();

            builder.HasOne(d => d.Anuncio)
                   .WithMany(a => a.Doacoes)
                   .HasForeignKey(d => d.AnuncioId);

            builder.HasIndex(d => d.AnuncioId);
        }
    }
}
