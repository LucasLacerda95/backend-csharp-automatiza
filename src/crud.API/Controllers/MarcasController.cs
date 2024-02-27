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

        public MarcasController(IMarcaRepository marcaRepository,
                                IMarcaService marcaService,     
                                IMapper mapper)//Injecao de dependencia
        {
            _marcaRepository = marcaRepository;
            _marcaService = marcaService;
            _mapper = mapper;
        }


        [HttpPost("")]
        public async Task<ActionResult<MarcaViewModel>> Adicionar(MarcaViewModel marcaViewModel) {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _marcaService.Adicionar(_mapper.Map<Marca>(marcaViewModel));//Binding de uma view Model em uma Entidade Entity

            return Ok();
        }


        [HttpGet("")]
        public async Task<IEnumerable<MarcaViewModel>> ObterTodos()
        {

            var marca = _mapper.Map<IEnumerable<MarcaViewModel>>(await _marcaRepository.ObterTodos());
            return marca;
            //Optei por não retornar um action result para diminuir a complexidade do retorno
            //naturalmente será um 200
        }


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MarcaViewModel>> ObterPorId(Guid id)
        {
            var marcaViewModel = await ObterMarca(id);

            if (marcaViewModel == null) return NotFound();

            return marcaViewModel;
        }



        private async Task<MarcaViewModel> ObterMarca(Guid id)
        {
            return _mapper.Map<MarcaViewModel>(await _marcaRepository.ObterMarcaPorId(id));
        }

    }


}
