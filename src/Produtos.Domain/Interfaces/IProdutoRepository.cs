using Produtos.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Produtos.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> Get();

        Task<List<Produto>> GetAllFilterPaginator(string codigoFornecedor, int pageNumber, int pageSize);

        Task<Produto> GetProdutoByCode(int codigo);

        Task<Produto> Create(Produto produto);

        Task Delete(int codigo);
    }
}