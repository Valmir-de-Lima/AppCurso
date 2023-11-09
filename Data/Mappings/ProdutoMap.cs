using AppCurso.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCurso.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            // Tabela
            builder.ToTable("Produto");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Propriedades            
            builder.Property(x => x.Descricao)
                 .IsRequired()  // NT NULL
                 .HasColumnName("Descricao")
                 .HasColumnType("TEXT")
                 .HasMaxLength(80);

            builder.Property(x => x.Preco)
                 .IsRequired()  // NT NULL
                 .HasColumnName("Preco")
                 .HasColumnType("REAL");

            // Relacionamentos um para muitos
            // builder.HasOne(x => x.Modulo)
            //     .WithMany(x => x.Aulas)
            //     .HasConstraintName("FK_Aula_Modulo")
            //     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}