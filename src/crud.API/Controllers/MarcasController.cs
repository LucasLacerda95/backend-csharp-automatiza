using AutoMapper;
using crud.API.ViewModels;
using crud.BLL.Interfaces;
using crud.BLL.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


namespace crud.API.Controllers
{
    [Route("api/marcas")]
    public class MarcasController : ControllerBase
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
        public async Task<ActionResult<MarcaViewModel>> Adicionar([FromBody] MarcaViewModel marcaViewModel) {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _marcaService.Adicionar(_mapper.Map<Marca>(marcaViewModel));//Binding de uma view Model em uma Entidade Entity

            return Ok($"Marca {marcaViewModel.Descricao} foi adicionada com êxito!");
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
        public async Task<ActionResult<MarcaViewModel>> ObterPorId([FromRoute] Guid id)
        {
            var marcaViewModel = await ObterMarca(id);

            if (marcaViewModel == null) return NotFound();

            return marcaViewModel;
        }


        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] MarcaViewModel marcaViewModel)
        {
            if (id != marcaViewModel.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) return BadRequest();

            await _marcaService.Atualizar(_mapper.Map<Marca>(marcaViewModel));

            return Ok($"Marca {marcaViewModel.Descricao} foi atualizada com êxito!");
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<MarcaViewModel>> Excluir([FromRoute] Guid id)//SoftDelete
        {
            var marca = await ObterMarca(id);

            if (marca == null) return NotFound();

            await _marcaService.Remover(id);

            return Ok("Marca deletada com êxito!");
        }



        private async Task<MarcaViewModel> ObterMarca(Guid id)
        {
            return _mapper.Map<MarcaViewModel>(await _marcaRepository.ObterMarcaPorId(id));
        }


    }


}
