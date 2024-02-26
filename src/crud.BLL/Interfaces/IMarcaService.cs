using crud.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.BLL.Interfaces
{
    public interface IMarcaService : IDisposable
    {
        Task Adicionar(Marca marca);
        Task Atualizar(Marca marca);
        Task Remover(Guid codigo);
    }
}
