using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewNerdStore.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewNerdStore.Catalogo.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Descricao)
               .IsRequired()
               .HasColumnType("varchar(500)");

            builder.Property(c => c.Imagem)
               .IsRequired()
               .HasColumnType("varchar(250)");

            builder.Property(c => c.Valor)
                .HasColumnType("decimal");

            builder.OwnsOne(c => c.Dimensoes, cm =>
            {
                cm.Property(c => c.Altura)
                    .HasColumnName("Altura")
                    .HasColumnType("float");

                cm.Property(c => c.Largura)
                    .HasColumnName("Largura")
                    .HasColumnType("float");

                cm.Property(c => c.Comprimento)
                    .HasColumnName("Comprimento")
                    .HasColumnType("float");
            });

            builder.ToTable("Produtos");
        }
    }
}
