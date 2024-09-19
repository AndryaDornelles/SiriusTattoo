using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Repositories.Mappings
{
    public class TatuagensMap : IEntityTypeConfiguration<TatuagensModel>
    {
        public void Configure(EntityTypeBuilder<TatuagensModel> builder)
        {
            //Indica qual é a tabela
            builder.ToTable("Tatuagens");

            //Indica qual é a chave primária
            builder.HasKey(x => x.Id);

            //Serve para mapear os objetos com os campos da tabela
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .IsRequired();

            builder.Property(x => x.Preco)
                .HasColumnName("Preco")
                .IsRequired();

            // Configura o relacionamento com Tatuador
            builder.Property(x => x.Tatuadores)
                .HasColumnName("Tatuador_Id")
                .IsRequired();

            builder.HasOne(x => x.Tatuadores)
                .WithMany() // Um tatuador pode ter várias Tatuagens
                .HasForeignKey(x => x.Tatuadores.Id); // Define a chave estrangeira

            builder.Property(x => x.Imagem)
                .HasColumnName("Imagem")
                .IsRequired();
        }
    }
}
