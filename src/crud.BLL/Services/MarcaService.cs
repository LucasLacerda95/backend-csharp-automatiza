using crud.BLL.Interfaces;
using crud.BLL.Models;
using crud.BLL.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace crud.BLL.Services
{
    public class MarcaService : BaseService, IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }


        public async Task Adicionar(Marca marca)
        {
            await _marcaRepository.Adicionar(marca);
        }

        public async Task Atualizar(Marca marca)
        {
            
            await _marcaRepository.Atualizar(marca);
        }

        public async Task Remover(Guid id)
        {
            await _marcaRepository.Remover(id);
        }



        public void Dispose()
        {
            _marcaRepository?.Dispose();
        }
    }
}
