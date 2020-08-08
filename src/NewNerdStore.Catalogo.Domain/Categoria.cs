﻿using NewNerdStore.Core.DomainObjects;
using System.Collections.Generic;

namespace NewNerdStore.Catalogo.Domain
{
    public class Categoria : Entity
    {

        public string Nome { get; private set; }
        public string Codigo { get; private set; }

        public ICollection<Produto> Produtos { get; set; }

        protected Categoria()
        {

        }

        public Categoria(string nome, string codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        private void Validar()
        {
            AssertionConcern.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
            AssertionConcern.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode ser 0");
        }
    }
}
