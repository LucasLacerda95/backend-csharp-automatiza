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
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {

        public ProdutoRepository(DataContext context) : base(context) { }

        public async Task<Produto> ObterProdutoPorId(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id) ?? new Produto();
        }

        public async Task Remover(Guid id)//SoftDelete
        {
            Produto produtoDb = await ObterProdutoPorId(id);
            produtoDb.Situacao = "INATIVO";
            DbSet.Update(produtoDb);

            await SaveChanges();
        }

    }
}
