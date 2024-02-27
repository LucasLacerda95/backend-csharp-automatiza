using AutoMapper;
using crud.API.ViewModels;
using crud.BLL.Interfaces;
using crud.BLL.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace crud.API.Controllers
{
    [Route("api/marcas")]
    public class MarcasController : MainController
    {

        private readonly IMarcaRepository _marcasRepository;
        private readonly IMapper _mapper;

        public MarcasController(IMarcaRepository marcaRepository, 
                                IMapper mapper)//Injecao de dependencia
        {
            _marcasRepository = marcaRepository;
            _mapper = mapper;
        }


        [HttpGet("obterTodos")]
        public async Task<IEnumerable<MarcaViewModel>> ObterTodos()
        {

            var marca = _mapper.Map<IEnumerable<MarcaViewModel>>(await _marcasRepository.ObterTodos());
            return marca;
            //Optei por não retornar um action result para diminuir a complexidade do retorno
            //naturalmente será um 200
        }


    }

     
}
