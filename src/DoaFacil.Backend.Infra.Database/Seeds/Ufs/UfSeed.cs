using DoaFacil.Backend.Domain.Entities.UfEntity;
using DoaFacil.Backend.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace DoaFacil.Backend.Infra.Database.Seeds.Ufs
{
    public class UfSeed(IRepositoryContext context)
    {
        private DbSet<Uf> DbSetUf => context.Set<Uf>();

        private static List<Uf> Ufs =>
        [
            new Uf(Guid.NewGuid(), "AC", "Acre"),
            new Uf(Guid.NewGuid(), "AL", "Alagoas"),
            new Uf(Guid.NewGuid(), "AP", "Amapá"),
            new Uf(Guid.NewGuid(), "AM", "Amazonas"),
            new Uf(Guid.NewGuid(), "BA", "Bahia"),
            new Uf(Guid.NewGuid(), "CE", "Ceará"),
            new Uf(Guid.NewGuid(), "DF", "Distrito Federal"),
            new Uf(Guid.NewGuid(), "ES", "Espírito Santo"),
            new Uf(Guid.NewGuid(), "GO", "Goiás"),
            new Uf(Guid.NewGuid(), "MA", "Maranhão"),
            new Uf(Guid.NewGuid(), "MT", "Mato Grosso"),
            new Uf(Guid.NewGuid(), "MS", "Mato Grosso do Sul"),
            new Uf(Guid.NewGuid(), "MG", "Minas Gerais"),
            new Uf(Guid.NewGuid(), "PA", "Pará"),
            new Uf(Guid.NewGuid(), "PB", "Paraíba"),
            new Uf(Guid.NewGuid(), "PR", "Paraná"),
            new Uf(Guid.NewGuid(), "PE", "Pernambuco"),
            new Uf(Guid.NewGuid(), "PI", "Piauí"),
            new Uf(Guid.NewGuid(), "RJ", "Rio de Janeiro"),
            new Uf(Guid.NewGuid(), "RN", "Rio Grande do Norte"),
            new Uf(Guid.NewGuid(), "RS", "Rio Grande do Sul"),
            new Uf(Guid.NewGuid(), "RO", "Rondônia"),
            new Uf(Guid.NewGuid(), "RR", "Roraima"),
            new Uf(Guid.NewGuid(), "SC", "Santa Catarina"),
            new Uf(Guid.NewGuid(), "SP", "São Paulo"),
            new Uf(Guid.NewGuid(), "SE", "Sergipe"),
            new Uf(Guid.NewGuid(), "TO", "Tocantins")
        ];

        public void Execute() => Ufs.ForEach(Handle);

        private void Handle(Uf uf)
        {
            if (DbSetUf.Any(x => x.Sigla == uf.Sigla)) return;
            else DbSetUf.Add(uf);
        }
    }
}
