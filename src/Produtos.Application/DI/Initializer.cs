using Produtos.Domain.Interfaces;
using Produtos.Domain.Models;
using Produtos.Infra.Context;
using Produtos.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Produtos.Application.DI {
    public class Initializer {
        public static void Configure (IServiceCollection services, string conection) 
        {
            services.AddDbContext<AppDbContext> (options => options.UseSqlServer (conection));
            services.AddScoped (typeof (IProdutoRepository), typeof (ProdutoRepository));
            services.AddScoped (typeof (ProdutoService));
            services.AddScoped (typeof (IUnitOfWork), typeof (UnitOfWork));
        }
    }
}