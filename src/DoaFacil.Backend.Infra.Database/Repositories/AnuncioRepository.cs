using DoaFacil.Backend.Domain.Entities.AnuncioEntity;
using DoaFacil.Backend.Domain.Repositories;
using DoaFacil.Backend.Infra.Database.Context;
using DoaFacil.Backend.Infra.Database.Repositories.Base;
using DoaFacil.Backend.Shared.Dtos.Anuncios;
using DoaFacil.Backend.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace DoaFacil.Backend.Infra.Database.Repositories
{
    public class AnuncioRepository(IRepositoryContext context) : Repository<Anuncio>(context), IAnuncioRepository
    {
        public async Task<int> GetMaxCodigoAsync(CancellationToken cancellationToken)
            => (await _dbSet.MaxAsync(x => (int?)x.Codigo, cancellationToken)) ?? 0;

        public async Task<List<AnuncioLista.Data>> GetAnunciosAsync(AnuncioLista.Filtro filtro, Guid usuarioId, CancellationToken cancellationToken)
        {
            var query = BuildFiltroGetAnuncios(filtro, usuarioId);
            return await query.Select(x => new AnuncioLista.Data
            {
                Anunciante = x.Usuario.Nome,
                Codigo = x.Codigo,
                AnuncioPessoal = x.UsuarioId == usuarioId,
                DataAnuncio = x.Data,
                Doado = x.Doacoes.Sum(x => (decimal?)x.Valor) ?? 0,
                Id = x.Id,
                ImagemBytes = x.Imagens.FirstOrDefault().Conteudo,
                ImagemNome = x.Imagens.FirstOrDefault().Nome,
                ImagemTipo = x.Imagens.FirstOrDefault().Tipo,
                Meta = x.Meta,
                NomeCategoria = x.Categoria.Nome,
                Titulo = x.Titulo,
            }).ToListAsync(cancellationToken);
        }

        public async Task<AnuncioDetalhesDto> GetAnuncioDetalhesAsync(Guid anuncioId, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking()
                .Where(x => x.Id == anuncioId)
                .Select(x => new AnuncioDetalhesDto
                {
                    Id = x.Id,
                    Meta = x.Meta,
                    Titulo = x.Titulo,
                    Codigo = x.Codigo,
                    DataAnuncio = x.Data,
                    ChavePix = x.ChavePix,
                    Descricao = x.Descricao,
                    Anunciante = x.Usuario.Nome,
                    NomeCategoria = x.Categoria.Nome,
                    Arrecadado = x.Doacoes.Sum(x => x.Valor),
                    ImagemTipo = x.Imagens.FirstOrDefault().Tipo,
                    ImagemBytes = x.Imagens.FirstOrDefault().Conteudo,
                    TotalApoiadores = x.Doacoes.GroupBy(x => x.UsuarioId).Count(),
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<AnuncioEditDto> GetAnuncioEditAsync(Guid anuncioId, CancellationToken cancellationToken)
            => await (
                from anuncio in _dbSet.AsQueryable()
                join img in _context.ImagensAnuncios on anuncio.Id equals img.AnuncioId
                where anuncio.Id == anuncioId
                select new AnuncioEditDto
                {
                    Id = anuncio.Id,
                    CategoriaId = anuncio.CategoriaId,
                    ChavePix = anuncio.ChavePix,
                    Descricao = anuncio.Descricao,
                    Imagem = new ImagemAnuncioEditDto
                    {
                        Bytes = img.Conteudo,
                        Nome = img.Nome,
                        Principal = img.Principal,
                        Tipo = img.Tipo,
                    },
                    Meta = anuncio.Meta,
                    Titulo = anuncio.Titulo,
                }
            ).FirstOrDefaultAsync(cancellationToken);

        private IQueryable<Anuncio> BuildFiltroGetAnuncios(AnuncioLista.Filtro filtro, Guid usuarioId)
        {
            var query = _dbSet
                .Include(x => x.Usuario)
                .Include(x => x.Categoria)
                .Include(x => x.Imagens)
                .Include(x => x.Doacoes)
                .OrderByDescending(x => x.Data)
                .AsNoTracking();

            if (filtro.SomenteAnuncioPessoal)
                query = query.Where(x => x.UsuarioId == usuarioId);

            if (!string.IsNullOrWhiteSpace(filtro.Search))
            {
                bool isValidCodigo = int.TryParse(filtro.Search, out int codigo);

                query = query.Where(x => EF.Functions.Like(x.Usuario.Nome, "%" + filtro.Search + "%") ||
                    EF.Functions.Like(x.Categoria.Nome, "%" + filtro.Search + "%") ||
                    EF.Functions.Like(x.Titulo, "%" + filtro.Search + "%") ||
                    (isValidCodigo && x.Codigo == codigo));
            }

            if (filtro.Data != AnuncioFiltroData.Qualquer)
            {
                var now = DateTime.Now.Date;
                switch (filtro.Data)
                {
                    case AnuncioFiltroData.Hoje:
                        query = query.Where(x => x.Data.Date == now); 
                        break;
                    case AnuncioFiltroData.EstaSemana:
                        var inicioDaSemana = now.Date.AddDays(-(int)now.DayOfWeek);
                        var fimDaSemana = inicioDaSemana.AddDays(7);
                        query = query.Where(x => x.Data.Date >= inicioDaSemana.Date && x.Data.Date < fimDaSemana.Date);
                        break;
                    case AnuncioFiltroData.EsteMes:
                        var inicioDoMes = new DateTime(now.Year, now.Month, 1);
                        var fimDoMes = inicioDoMes.AddMonths(1).AddDays(-1);
                        query = query.Where(x => x.Data.Date >= inicioDoMes.Date && x.Data.Date <= fimDoMes.Date);
                        break;
                    case AnuncioFiltroData.EsteAno:
                        var inicioDoAno = new DateTime(now.Year, 1, 1);
                        var fimDoAno = new DateTime(now.Year, 12, 31);
                        query = query.Where(x => x.Data.Date >= inicioDoAno.Date && x.Data.Date <= fimDoAno.Date);
                        break;
                }
            }

            if (filtro.CategoriaId.HasValue)
                query = query.Where(x => x.CategoriaId == filtro.CategoriaId);

            if (filtro.Take.HasValue)
                query = query.Take(filtro.Take.Value);  

            return query;
        }
    }
}
