using AppCurso.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCurso.Data.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            // Tabela
            builder.ToTable("Pedido");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Propriedades            
            builder.Property(x => x.Cliente)
                 .IsRequired()  // NT NULL
                 .HasColumnName("Cliente")
                 .HasColumnType("TEXT")
                 .HasMaxLength(80);

            // Propriedades            
            builder.Property(x => x.Status)
                 .HasColumnName("Status")
                 .HasColumnType("TEXT")
                 .HasMaxLength(80);

            builder.Property(x => x.Total)
                 .IsRequired()  // NT NULL
                .HasColumnName("Total")
                .HasColumnType("TEXT");

            // Relacionamento M:N com a tabela de junção
            builder
                .HasMany(pedido => pedido.Produtos)
                .WithMany(produto => produto.Pedidos)
                .UsingEntity(j => j.ToTable("PedidoProduto"));

            // Indice auxiliar
            builder
                .HasIndex(x => x.Cliente, "IX_Pedido_Cliente");
        }
    }
}