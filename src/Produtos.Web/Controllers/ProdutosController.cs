using System.Collections.Generic;
using System.Linq;
using Produtos.Domain.Interfaces;
using Produtos.Domain.Models;
using Produtos.Web.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Produtos.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ProdutoService _produtoServicey;

        public ProdutosController(IProdutoRepository produtoRepository, ProdutoService produtoService)
        {
            _produtoRepository = produtoRepository;
            _produtoServicey = produtoService;
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<Produto>> GetProdutoByCode(int code)
        {
            return await _produtoRepository.GetProdutoByCode(code);
        }

        [HttpGet]
        public async Task<List<Produto>> GetAllFilterPaginator([FromQuery] Filter filter)
        {
            return await _produtoRepository.GetAllFilterPaginator(filter.CodigoFornecedor, filter.PageNumber, filter.PageSize);
        }


        [HttpPost]
        public async Task<ActionResult<Produto>> Insert([FromBody] Produto produto)
        {
            await _produtoServicey.Create(0,
                                          produto.Descricao,
                                          produto.Situacao,
                                          produto.DataFabricacao,
                                          produto.DataValidade,
                                          produto.CodigoFornecedor,
                                          produto.DescricaoFornecedor,
                                          produto.CnpjFornecedor);

            return CreatedAtAction(nameof(produto), new { id = produto.Id });
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id) return BadRequest();

            await _produtoServicey.Create(id, produto.Descricao, produto.Situacao, produto.DataFabricacao, produto.DataValidade, produto.CodigoFornecedor, produto.DescricaoFornecedor, produto.CnpjFornecedor);

            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Delete(int codigo)
        {
            await _produtoRepository.Delete(codigo);
            return NoContent();
        }

    }
}