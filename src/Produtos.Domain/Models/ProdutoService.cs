using Produtos.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Produtos.Domain.Models
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Create(int codigo, string descricao, bool situacao, DateTime dataFabricacao, DateTime dataValidade, string codigoFornecedor, string descricaoFornecedor, string cnpjFornecedor)
        {
            var produto = await _produtoRepository.GetProdutoByCode(codigo);

            if (produto == null)
            {
                produto = new Produto(descricao, situacao, dataFabricacao, dataValidade, codigoFornecedor, descricaoFornecedor, cnpjFornecedor);
                await _produtoRepository.Create(produto);
            }
            else
            {
                produto.Update(descricao, situacao, dataFabricacao, dataValidade, codigoFornecedor, descricaoFornecedor, cnpjFornecedor);
            }
        }

    }
}