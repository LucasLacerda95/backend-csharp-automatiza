using Microsoft.EntityFrameworkCore;
using crud.BLL.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace crud.DAL.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.ProdutoID);

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

            // 1 => 1  -- Produto -> Marca
            builder.HasOne(m => m.MarcaId)
                .WithOne(p => p.ProdutoId);

            builder.ToTable("Produtos");

        }

    }
}
