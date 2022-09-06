using AppCurso.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppCurso.Data.Mappings
{
    public class ModuloMap : IEntityTypeConfiguration<Modulo>
    {
        public void Configure(EntityTypeBuilder<Modulo> builder)
        {
            // Tabela
            builder.ToTable("Modulo");

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

            builder.Property(x => x.OrdemExibicao)
                 .IsRequired()  // NT NULL
                 .HasColumnName("OrdemDeExibicao")
                 .HasColumnType("INTEGER");

            // Relacionamentos um para muitos
            builder.HasOne(x => x.Curso)
                .WithMany(x => x.Modulos)
                .HasConstraintName("FK_Modulo_Curso")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}