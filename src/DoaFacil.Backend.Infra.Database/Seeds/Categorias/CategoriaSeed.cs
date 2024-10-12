using DoaFacil.Backend.Domain.Entities.CategoriaEntity;
using DoaFacil.Backend.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace DoaFacil.Backend.Infra.Database.Seeds.Categorias
{
    public class CategoriaSeed(IRepositoryContext context)
    {
        private DbSet<Categoria> DbSetCategoria => context.Set<Categoria>();

        private static List<Categoria> Categorias =>
        [
            new Categoria(Guid.NewGuid(), "Saúde"),
            new Categoria(Guid.NewGuid(), "Ações sociais"),
            new Categoria(Guid.NewGuid(), "Educação"),
            new Categoria(Guid.NewGuid(), "Projetos culturais"),
            new Categoria(Guid.NewGuid(), "Esportes"),
            new Categoria(Guid.NewGuid(), "Animais"),
            new Categoria(Guid.NewGuid(), "Viagens e turismo"),
            new Categoria(Guid.NewGuid(), "Empreendedorismo"),
        ];

        public void Execute() => Categorias.ForEach(Handle);

        private void Handle(Categoria uf)
        {
            if (DbSetCategoria.Any(x => x.Nome == uf.Nome)) return;
            else DbSetCategoria.Add(uf);
        }
    }
}
