using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NewNerdStore.Catalogo.Application.Services;
using NewNerdStore.Catalogo.Data;
using NewNerdStore.Catalogo.Data.Repository;
using NewNerdStore.Catalogo.Domain.Events;
using NewNerdStore.Catalogo.Domain.Repositories;
using NewNerdStore.Catalogo.Domain.Services;
using NewNerdStore.Core.Communication.Mediatr;
using NewNerdStore.Core.Messages.CommonMessages.Notifications;
using NewNerdStore.Vendas.Application.Commands;

namespace NewNerdStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatrHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();

            //Vendas
            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();
        }
    }
}
