using MediatR;
using NewNerdStore.Catalogo.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace NewNerdStore.Catalogo.Domain.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoEventHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancelationToken)
        {
            var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);

            //Realizar as tarefas/integração para executar a reposição do produto
        }
    }
}

