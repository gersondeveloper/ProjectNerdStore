using AutoMapper;
using NewNerdStore.Catalogo.Application.ViewModels;
using NewNerdStore.Catalogo.Domain;
using NewNerdStore.Catalogo.Domain.ValueObjects;

namespace NewNerdStore.Catalogo.Application.AutoMapper
{
    public class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<ProdutoViewModel, Produto>()
                .ConstructUsing(p => new Produto(p.Nome, p.Descricao, p.Ativo, p.Valor, p.CategoriaId, p.DataCadastro, p.Imagem, new Dimensoes(p.Largura, p.Altura, p.Comprimento)));

            CreateMap<CategoriaViewModel, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
        }
    }
}
