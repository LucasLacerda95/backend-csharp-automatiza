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
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }


        public async Task Adicionar(Marca marca)
        {
            //if (!ExecutarValidacao(new ProdutoValidation(), produto)) return;

            await _marcaRepository.Adicionar(marca);
        }

        public async Task Atualizar(Marca marca)
        {
            
            await _marcaRepository.Adicionar(marca);
        }

      

        public void Dispose()
        {
            _marcaRepository?.Dispose();
        }
    }
}
