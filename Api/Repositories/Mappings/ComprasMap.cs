using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Mappings
{
    public class ComprasMap : IEntityTypeConfiguration<ComprasModel>
    {
        public void Configure(EntityTypeBuilder<ComprasModel> builder)
        {
            //Indica qual é a tabela
            builder.ToTable("Compras");

            //Indica qual é a chave primária
            builder.HasKey(x => x.Id);

            //Serve para mapear os objetos com os campos da tabela
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Configura o relacionamento com Cliente
            builder.Property(x => x.Cliente)
                .HasColumnName("Cliente_Id")
                .IsRequired();

            builder.HasOne(a => a.Cliente) // Navegação
                .WithMany() // Um cliente pode ter várias Compras
                .HasForeignKey(a => a.Cliente.Id); // Define a chave estrangeira

            // Configura o relacionamento com Tatuagem
            builder.Property(x => x.Tatuagem)
                .HasColumnName("Tatuagem_Id")
                .IsRequired();

            builder.HasOne(a => a.Tatuagem) // Navegação
                .WithOne() // Uma tatuagem só pode ter uma Compra
                .HasForeignKey<ComprasModel>(a => a.Tatuagem.Id);
        }
    }
}
