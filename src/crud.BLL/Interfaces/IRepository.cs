using crud.BLL.Models;
using System.Linq.Expressions;


namespace crud.BLL.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity: Entity
    {
       
        Task<List<TEntity>> ObterTodos();

    }
}
