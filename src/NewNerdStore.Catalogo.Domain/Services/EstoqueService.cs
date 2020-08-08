using NewNerdStore.Catalogo.Domain.Repositories;
using System;
using System.Threading.Tasks;
using NewNerdStore.Catalogo.Domain.Events;
using NewNerdStore.Core.Messages.CommonMessages.Notifications;
using NewNerdStore.Core.Communication.Mediatr;

namespace NewNerdStore.Catalogo.Domain.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatorHandler _mediatrHandler;

        //Ação de negócio - Será debitado o estoque quando houver a compra
        public EstoqueService(IProdutoRepository produtoRepository, IMediatorHandler mediatrHandler)
        {
            _produtoRepository = produtoRepository;
            _mediatrHandler = mediatrHandler;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);
            if (produto == null)
            {
                return false;
            }

            if (!produto.PossuiEstoque(quantidade))
            {
                //TODO: checar esse erro
                //await _mediatrHandler.PublicarEvento(new DomainNotification("Estoque", $"Produto - {produto.Nome} sem estoque"));
                return false;
            }

            //TODO: Parametrizar quantidade 
            if (produto.QuantidadeEstoque < 10)
            {
                await _mediatrHandler.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produtoId, produto.QuantidadeEstoque));
            }

            produto.DebitarEstoque(quantidade);

            _produtoRepository.Atualizar(produto);

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);
            if (produto == null)
            {
                return false;
            }
            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
