using DoaFacil.Backend.Domain.Entities.CategoriaEntity;
using DoaFacil.Backend.Infra.Database.Mappings.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoaFacil.Backend.Infra.Database.Mappings
{
    public class CategoriaMap : BaseEntityMap<Categoria>
    {
        public override string TableName => "categoria";

        public override void Configure(EntityTypeBuilder<Categoria> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(Categoria.NOME_MAX_LENGTH);
        }
    }
}
