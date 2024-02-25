using crud.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace crud.DAL.Mappings
{
    public class MarcaMapping : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.HasKey(m => m.MarcaID);

            builder.Property(m => m.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(m => m.Status)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Marcas");
        }
    }
}
