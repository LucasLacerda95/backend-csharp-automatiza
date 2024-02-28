using crud.BLL.Models;
using System.Linq.Expressions;


namespace crud.BLL.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity: Entity
    {
        Task Adicionar(TEntity entity);           
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity entity);
        

    }
}
