using AutoMapper;
using NewNerdStore.Catalogo.Application.ViewModels;
using NewNerdStore.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewNerdStore.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(l => l.Largura, o => o.MapFrom(s => s.Dimensoes.Largura))
                .ForMember(l => l.Altura, o => o.MapFrom(s => s.Dimensoes.Altura))
                .ForMember(l => l.Comprimento, o => o.MapFrom(s => s.Dimensoes.Comprimento)).ReverseMap();
            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
