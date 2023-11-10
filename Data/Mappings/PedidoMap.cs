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

            builder.Property(x => x.Descricao)
                 .IsRequired()  // NT NULL
                 .HasColumnName("Descricao")
                 .HasColumnType("TEXT")
                 .HasMaxLength(80);

            builder.Property(x => x.Preco)
                 .IsRequired()  // NT NULL
                 .HasColumnName("Preco")
                 .HasColumnType("DECIMAL");
        }
    }
}