using crud.BLL.Interfaces;
using crud.BLL.Models;
using crud.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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




    }
}
