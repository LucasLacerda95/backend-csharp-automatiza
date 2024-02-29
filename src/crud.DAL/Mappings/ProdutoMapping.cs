using Microsoft.EntityFrameworkCore;
using crud.BLL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace crud.DAL.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(p => p.Preco)
                .IsRequired();

            builder.Property(p => p.Estoque)
                .IsRequired();

            builder.Property(p => p.Situacao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.id_Marca)
                .IsRequired();

            builder.ToTable("Produtos");

        }

    }
}
