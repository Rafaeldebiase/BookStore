using bookstore.domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bookstore.data
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");

            builder.HasKey(campo => campo.Codigo);

            builder.Property(campo => campo.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("int");
            
            builder.Property(campo => campo.Titulo)
                .HasColumnName("titulo")
                .HasColumnType("varchar(200)");

            builder.Property(campo => campo.SubTitulo)
                .HasColumnName("sub_titulo")
                .HasColumnType("varchar(200)");
            
            builder.Property(campo => campo.Isbn)
                .HasColumnName("isbn")
                .HasColumnType("char(13)");
            
            builder.OwnsOne(campo => campo.Autor, autor => 
            {
                autor.Property(campo => campo.PrimeiroNomeDoAutor)
                    .HasColumnName("primeiro_nome")
                    .HasColumnType("varchar(200)");

                autor.Property(campo => campo.SobreNomeDoAutor)
                    .HasColumnName("sobre_nome")
                    .HasColumnType("varchar(200)");
            });

            builder.Property(campo => campo.AnoDeLancamento)
                .HasColumnName("ano_de_lancamento")
                .HasColumnType("char(15)");
        }
    }
}