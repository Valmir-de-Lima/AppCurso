using AppCurso.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCurso.Data.Mappings
{
    public class AulaMap : IEntityTypeConfiguration<Aula>
    {
        public void Configure(EntityTypeBuilder<Aula> builder)
        {
            // Tabela
            builder.ToTable("Aula");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Propriedades            
            builder.Property(x => x.Titulo)
                 .IsRequired()  // NT NULL
                 .HasColumnName("Titulo")
                 .HasColumnType("TEXT")
                 .HasMaxLength(80);

            builder.Property(x => x.Descricao)
                 .IsRequired()  // NT NULL
                 .HasColumnName("Descricao")
                 .HasColumnType("TEXT")
                 .HasMaxLength(80);

            builder.Property(x => x.UrlVideoAula)
                 .IsRequired()  // NT NULL
                 .HasColumnName("UrlVideoAula")
                 .HasColumnType("TEXT")
                 .HasMaxLength(120);

            // Relacionamentos um para muitos
            builder.HasOne(x => x.Modulo)
                .WithMany(x => x.Aulas)
                .HasConstraintName("FK_Aula_Modulo")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}