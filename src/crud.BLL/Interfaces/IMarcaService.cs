using crud.BLL.Models;


namespace crud.BLL.Interfaces
{
    public interface IMarcaService : IDisposable
    {
        Task Adicionar(Marca marca);
        Task Atualizar(Marca marca);
        //Task Remover(Guid id);
    }
}
