
using crud.BLL.Models;

namespace crud.BLL.Interfaces
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        Task<Marca> ObterMarcaPorId(Guid Id);
        //Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        //Task<Produto> ObterProdutoFornecedor(Guid id);

    }
}
