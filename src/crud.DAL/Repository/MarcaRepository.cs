using crud.BLL.Interfaces;
using crud.BLL.Models;
using crud.DAL.Context;
using Microsoft.EntityFrameworkCore;


namespace crud.DAL.Repository
{
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        public MarcaRepository(DataContext context) : base(context) { }

        public async Task<Marca> ObterMarcaPorId(Guid id)
        {
            return await Db.Marcas.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id) ?? new Marca(); 
        }

        public async Task Remover(Guid id)//SoftDelete
        {
            Marca marcaDb = await ObterMarcaPorId(id);
            marcaDb.Situacao = "REMOVIDO";
            DbSet.Update(marcaDb);

            await SaveChanges();
        }


    }
}
