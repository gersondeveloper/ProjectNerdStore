using FluentValidation;
using NewNerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewNerdStore.Vendas.Application.Commands
{
    public class AdicionarItemPedidoCommand : Command
    {
        public AdicionarItemPedidoCommand(Guid clienteId, Guid produtoId, string nome, int quantidade, decimal valorUnitario)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            Nome = nome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        public override bool EhValido()
        {
            return new AdicionarItemPedidoCommandValidator().Validate(this).IsValid;
        }

    }

    public class AdicionarItemPedidoCommandValidator : AbstractValidator<AdicionarItemPedidoCommand>
    {
        public AdicionarItemPedidoCommandValidator()
        {
            RuleFor(c => c.ClienteId).NotEqual(Guid.Empty).WithMessage("Id do cliente inválido");
            RuleFor(c => c.ProdutoId).NotEqual(Guid.Empty).WithMessage("Id do produto inválido");
            RuleFor(c => c.Nome).NotEmpty().WithMessage("Nome do produto não foi informado");
            RuleFor(c => c.Quantidade).GreaterThan(0).WithMessage("Quantidade mínima é 1");
            RuleFor(c => c.Quantidade).LessThan(15).WithMessage("Quantidade máxima do produto são 15 itens");
            RuleFor(c => c.ValorUnitario).GreaterThan(0).WithMessage("Valor do item precisa ser maior que 0");

        }
    }
}
