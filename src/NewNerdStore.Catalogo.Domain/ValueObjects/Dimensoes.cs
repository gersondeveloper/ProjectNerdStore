using NewNerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewNerdStore.Catalogo.Domain.ValueObjects
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Comprimento { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal comprimento)
        {
            AssertionConcern.ValidarSeMenorQue(altura, 1, "O campo Altura não pode ser menor ou igual a 0");
            AssertionConcern.ValidarSeMenorQue(largura, 1, "O campo Largura não pode ser menor ou igual a 0");
            AssertionConcern.ValidarSeMenorQue(comprimento, 1, "O campo Profundidade não pode ser menor ou igual a 0");

            Altura = altura;
            Largura = largura;
            Comprimento = comprimento;
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Comprimento}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }
    }
}
