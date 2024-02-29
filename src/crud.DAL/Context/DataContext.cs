using crud.BLL.Models;
using crud.DAL.Mappings;
using Microsoft.EntityFrameworkCore;


namespace crud.DAL.Context
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) {}


        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Preferível referenciar separadamente as classes em vez de buscar o assembly
            modelBuilder.ApplyConfiguration(new MarcaMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());

            base.OnModelCreating(modelBuilder);
        }

    }
}
