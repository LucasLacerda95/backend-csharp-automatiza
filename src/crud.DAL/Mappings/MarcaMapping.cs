﻿using crud.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace crud.DAL.Mappings
{
    public class MarcaMapping : IEntityTypeConfiguration<Marca>
    {
        public void Configure(EntityTypeBuilder<Marca> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Descricao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(m => m.Situacao)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Marcas");
        }
    }
}
