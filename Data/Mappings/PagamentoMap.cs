using AppCurso.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCurso.Data.Mappings
{
    public class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            // Tabela
            builder.ToTable("Pagamento");

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

            builder.Property(x => x.Total)
                 .IsRequired()  // NT NULL
                .HasColumnName("Total")
                .HasColumnType("TEXT");

            builder.HasOne(x => x.Pedido)
                .WithOne(p => p.Pagamento) // Um para um
                .HasForeignKey<Pagamento>(x => x.PedidoId);
        }
    }
}