using AutoMapper;
using crud.API.ViewModels;
using crud.BLL.Interfaces;
using crud.BLL.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace crud.API.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {


        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
                                IProdutoService produtoService,
                                IMapper mapper)//Injecao de dependencia
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }


        [HttpPost("")]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));//Binding de uma view Model em uma Entidade Entity

            return Ok();
        }


        [HttpGet("")]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {

            var produto = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.ObterTodos());
            return produto;
            //Optei por não retornar um action result para diminuir a complexidade do retorno
            //naturalmente será um 200
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
        {
            var produtoViewModel = await ObterProduto(id);

            if (produtoViewModel == null) return NotFound();

            return produtoViewModel;
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid) return BadRequest();

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoViewModel));

            return Ok(produtoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)//SoftDelete
        {
            var produto = await ObterProduto(id);

            if (produto == null) return NotFound();

            await _produtoService.Remover(id);

            return Ok("Deletado com êxito!");
        }




        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoPorId(id));
        }

    }
}
