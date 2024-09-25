using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Repositories.Mappings
{
    public class TatuadoresMap : IEntityTypeConfiguration<TatuadoresModel>
    {
        public void Configure(EntityTypeBuilder<TatuadoresModel> builder)
        {
            //Indica qual é a tabela
            builder.ToTable("Tatuadores");

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

            builder.Property(x => x.Especialidade)
                .HasColumnName("Especialidade")
                .IsRequired();
        }
    }
}
