﻿using DoaFacil.Backend.Infra.Crosscutting.Extensions;
using DoaFacil.Backend.Shared.Enums;

namespace DoaFacil.Backend.Shared.Dtos.Anuncios
{
    public static class AnuncioLista
    {
        public class Filtro
        {
            public bool SomenteAnuncioPessoal { get; set; }
            public string Search { get; set; }
            public AnuncioFiltroData Data { get; set; }
            public Guid? CategoriaId { get; set; }
            public int? Take { get; set; }
        }

        public class Data
        {
            public Guid Id { get; set; }
            public string ImagemNome { get; set; }
            public byte[] ImagemBytes { get; set; }
            public string ImagemTipo { get; set; }
            public string ImagemBase64 => ImagemBytes.ConvertImgToBase64(ImagemTipo);
            public string Titulo { get; set; }
            public string NomeCategoria { get; set; }
            public int Codigo { get; set; }
            public string Anunciante { get; set; }
            public decimal Meta { get; set; }
            public decimal Doado { get; set; }
            public DateTime DataAnuncio { get; set; }
            public bool AnuncioPessoal { get; set; }
        }
    }
}
