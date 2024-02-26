using Microsoft.EntityFrameworkCore;
using crud.BLL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace crud.DAL.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Codigo);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(p => p.Preco)
                .IsRequired();

            builder.Property(p => p.Estoque)
                .IsRequired();

            builder.Property(p => p.Status)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.codigo_Marca)
                .IsRequired();

            builder.ToTable("Produtos");

        }

    }
}
