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
                 .HasColumnName("Titulo")
                 .HasColumnType("TEXT")
                 .HasMaxLength(80);

            builder.Property(x => x.ProdutoId)
                 .IsRequired()  // NT NULL
                 .HasColumnName("ProdutoId")
                 .HasColumnType("INTEGER");

            // Relacionamento com Produto
            builder.HasOne(p => p.Produto)
                .WithMany()
                .HasForeignKey(p => p.ProdutoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}