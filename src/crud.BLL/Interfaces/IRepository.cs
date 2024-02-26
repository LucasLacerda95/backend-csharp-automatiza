using crud.BLL.Models;
using System.Linq.Expressions;


namespace crud.BLL.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity: Entity
    {
        Task Adicionar(TEntity entity);

        Task<TEntity> ObterPorID(Guid codigo);

        Task<List<TEntity>> ObterTodos();

        Task Atualizar(TEntity entity);

        Task Remover(Guid codigo);

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    }
}
