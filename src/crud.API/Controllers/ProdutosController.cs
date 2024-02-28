using AutoMapper;
using crud.API.ViewModels;
using crud.BLL.Interfaces;
using crud.BLL.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Newtonsoft.Json;

namespace crud.API.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {


        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        public ProdutosController(IProdutoRepository produtoRepository,
                                IProdutoService produtoService,
                                IMapper mapper,
                                IHttpClientFactory httpClientFactory)//Injecao de dependencia
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("API");
        }


        [HttpPost("")]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar([FromBody] ProdutoViewModel produtoViewModel)
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
        public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] ProdutoViewModel produtoViewModel)
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

        [HttpGet("catalogo/{ean}/imagens")]
        public async Task<ActionResult<List<string>>> UrlProduto([FromRoute] String ean) // Recebe o codigo de barras ean da rota
        {
            // Cria a variavel que recebe a resposta da API da automatiza com todas as suas informações (header, body, etc...)
            var httpResponseMessage = await _httpClient.GetAsync("https://catalogoautomatiza.azurewebsites.net/api/produtos/" + ean);

            // Verifica se a resposta foi de sucesso
            if (!httpResponseMessage.IsSuccessStatusCode)
                return BadRequest("API erro");

            // Desserializa o conteúdo da resposta na classe ApiProduto usando a biblioteca Newtonsoft.Json
            ApiProduto? apiProduto = JsonConvert.DeserializeObject<ApiProduto>(await httpResponseMessage.Content.ReadAsStringAsync());

            // Verifica se a resposta foi nula por algum motivo
            if(apiProduto == null) return NotFound();

            // Retorna apenas a Lista de links para as imagens do produto como solicitado no Read.me do projeto
            return Ok(apiProduto.Imagens);
        }
         

        private async Task<ProdutoViewModel> ObterProduto(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterProdutoPorId(id));
        }

    }
}
