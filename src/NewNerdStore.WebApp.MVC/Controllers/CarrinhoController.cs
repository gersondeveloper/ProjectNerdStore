using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewNerdStore.Catalogo.Application.Services;
using NewNerdStore.Core.Communication.Mediatr;
using NewNerdStore.Vendas.Application.Commands;

namespace NewNerdStore.WebApp.MVC.Controllers
{
    public class CarrinhoController : ControllerBase
    {
        public readonly IProdutoAppService _produtoAppService;
        public readonly IMediatorHandler _mediatorHandler;

        public CarrinhoController(IProdutoAppService produtoAppService, IMediatorHandler mediatorHandler)
        {
            _produtoAppService = produtoAppService;
            _mediatorHandler = mediatorHandler;
        }

        [HttpPost]
        [Route("carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            if (produto == null) return NotFound();

            if (produto.QuantidadeEmEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com esttoque insuficiente";
                return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
            }

            var comando = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);
            await _mediatorHandler.EnviarComando(comando);

            TempData["Erro"] = "Produto indisponível";
            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
        }


    }
}
