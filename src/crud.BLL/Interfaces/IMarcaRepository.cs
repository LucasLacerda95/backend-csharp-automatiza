
using crud.BLL.Models;

namespace crud.BLL.Interfaces
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        Task<Marca> ObterMarcaPorId(Guid Id);
        Task Remover(Guid id);

    }
}
