using DoaFacil.Backend.Domain.Entities.CidadeEntity;
using DoaFacil.Backend.Infra.Database.Mappings.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoaFacil.Backend.Infra.Database.Mappings
{
    public class CidadeMap : BaseEntityMap<Cidade>
    {
        public override string TableName => "cidade";

        public override void Configure(EntityTypeBuilder<Cidade> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(Cidade.NOME_MAX_LENGTH);
            builder.Property(c => c.UfId).IsRequired();

            builder.HasOne(c => c.Uf)
                   .WithMany(u => u.Cidades)
                   .HasForeignKey(c => c.UfId);

            builder.HasIndex(c => c.Nome).IsUnique();
            builder.HasIndex(c => c.UfId);
        }
    }
}
