using DoaFacil.Backend.Domain.Entities.UfEntity;
using DoaFacil.Backend.Infra.Database.Mappings.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoaFacil.Backend.Infra.Database.Mappings
{
    public class UfMap : BaseEntityMap<Uf>
    {
        public override string TableName => "uf";

        public override void Configure(EntityTypeBuilder<Uf> builder)
        {
            base.Configure(builder);

            builder.Property(u => u.Sigla).IsRequired().HasMaxLength(Uf.SIGLA_MAX_LENGTH);
            builder.Property(u => u.Nome).IsRequired().HasMaxLength(Uf.NOME_MAX_LENGTH);
        }
    }
}
