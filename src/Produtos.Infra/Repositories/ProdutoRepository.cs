using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Interfaces;
using Produtos.Domain.Models;
using Produtos.Infra.Context;

namespace Produtos.Infra.Repositories
{
    public class ProdutoRepository: IProdutoRepository
    {
        protected readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task Delete(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            produto.Delete(false);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produto>> Get()
        {
            return await _context.Produtos.ToListAsync();
        }

        public Task<List<Produto>> GetAllFilterPaginator(string codigoFornecedor, int pageNumber, int pageSize)
        {
            var productData = _context.Produtos
                .Where(c => c.CodigoFornecedor == codigoFornecedor)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return productData;
        }

        public async Task<Produto> GetProdutoByCode(int codigo)
        {
            return await _context.Produtos.FindAsync(codigo);
        }


    }
}