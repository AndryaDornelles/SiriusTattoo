using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.Mappings
{
    public class ClientesMap : IEntityTypeConfiguration<ClientesModel>
    {
        public void Configure(EntityTypeBuilder<ClientesModel> builder)
        {
            //Indica qual é a tabela
            builder.ToTable("Clientes");

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

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasColumnName("Senha")
                .IsRequired();

            builder.Property(x => x.Telefone)
                .HasColumnName("Telefone")
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .HasColumnName("Data_Nascimento")
                .IsRequired();
        }
    }
}
