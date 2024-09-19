using Api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Mappings
{
    public class AgendaMap : IEntityTypeConfiguration<AgendaModel>
    {
        public void Configure(EntityTypeBuilder<AgendaModel> builder)
        {
            //Indica qual é a tabela
            builder.ToTable("Agenda");

            //Indica qual é a chave primária
            builder.HasKey(x => x.Id);

            //Serve para mapear os objetos com os campos da tabela
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Configura o relacionamento com Cliente
            builder.Property(x => x.Cliente.Id)
                .HasColumnName("Cliente_Id")
                .IsRequired();

            builder.HasOne(a => a.Cliente) // Navegação
                .WithMany() // Um cliente pode ter várias Agendas
                .HasForeignKey(a => a.Cliente.Id); // Define a chave estrangeira

            // Configura o relacionamento com Tatuador
            builder.Property(x => x.Tatuador)
                .HasColumnName("Tatuador_Id")
                .IsRequired();

            builder.HasOne(a => a.Tatuador) // Navegação
                .WithMany() // Um tatuador pode ter várias Agendas
                .HasForeignKey(a => a.Tatuador.Id); // Define a chave estrangeira

            builder.Property(x => x.DataSessao)
                .HasColumnName("Data_Sessao")
                .IsRequired();

            builder.Property(x => x.Duracao)
                .HasColumnName("Duracao");

            builder.Property(x => x.Status)
                .HasColumnName("Status");



        }
    }
}
