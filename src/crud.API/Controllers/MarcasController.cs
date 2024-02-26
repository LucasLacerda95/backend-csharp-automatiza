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

        private readonly IMarcaRepository _marcaRepository;
        private readonly IMarcaService _marcaService;
        private readonly IMapper _mapper;



        public MarcasController(IMarcaRepository marcaRepository, //Injeção de dependência via Mapper
                                IMarcaService marcaService,
                                IMapper mapper)
        {
            _marcaRepository = marcaRepository;
            _marcaService = marcaService;
            _mapper = mapper;
        }

        [HttpPost("")]
        public async Task<ActionResult<MarcaViewModel>> AdicionarMarca([FromBody]MarcaViewModel marcaViewModel)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            await _marcaService.Adicionar(_mapper.Map<Marca>(marcaViewModel));
        }




    }

     
}
